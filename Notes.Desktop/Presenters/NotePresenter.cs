using Notes.Database.Repositories;
using Notes.Desktop.Interfaces.Presenters;
using Notes.Desktop.Interfaces.Views;
using Notes.Desktop.Views;
using Notes.Models;

namespace Notes.Desktop.Presenters;

/// <summary>
///     Реализация презентера для работы с заметками.
/// </summary>
internal class NotePresenter : INotePresenter {
    private readonly NoteRepository _noteRepository;
    private readonly INoteView _noteView;

    /// <summary>
    ///     Конструктор класса NotePresenter.
    /// </summary>
    /// <param name="noteView">Экземпляр представления заметок, с которым будет работать презентер</param>
    /// <param name="noteRepository">Экземпляр репозитория заметок, который будет использоваться для работы с данными</param>
    public NotePresenter(INoteView noteView, NoteRepository noteRepository) {
        _noteView = noteView;
        _noteRepository = noteRepository;

        _noteView.LoadNotes += OnLoadNotes;
        _noteView.AddNote += OnAddNote;
        _noteView.DeleteNote += OnDeleteNote;
        _noteView.SelectNote += OnSelectNote;
        _noteView.SearchNote += OnSearchNote;
    }

    public async void OnAddNote(string title, string? description = null) {
        try {
            await _noteRepository.CreateAsync(new Note {
                Title = title,
                Description = description,
                CreatedAt = DateTime.Now
            });

            // обновляем вьюху NoteListBox
            OnLoadNotes();
            _noteView.ClearNoteInput();

            _noteView.DisplayMessage("Заметка успешно добавлена");
        }
        catch (Exception ex) {
            _noteView.DisplayMessage($"Не удалось добавить заметку\n{ex.Message}", MessageBoxIcon.Error);
        }
    }

    public async void OnDeleteNote(Note note) {
        try {
            var isDeleted = await _noteRepository.DeleteAsync(note);
            if (!isDeleted) {
                _noteView.DisplayMessage("Не удалось удалить заметку", MessageBoxIcon.Error);
                return;
            }

            OnLoadNotes();
        }
        catch (Exception ex) {
            _noteView.DisplayMessage($"Не удалось удалить заметку\n{ex.Message}", MessageBoxIcon.Error);
        }
    }

    public void OnSelectNote(Note note) {
        CloseOtherForms();

        var noteDetailsForm = new NoteDetails(note) {
            Text = $@"Заметка от {note.CreatedAt:dd.MM.yyyy HH:mm:ss}"
        };
        noteDetailsForm.Show();
    }

    public async void OnSearchNote(string keyword) {
        var keywords = keyword.Split(' ');

        try {
            var notes = await _noteRepository.GetAllAsync();

            _noteView.DisplayNotes(notes
                .Where(SearchPredicate).ToList());
        }
        catch (Exception ex) {
            _noteView.DisplayMessage($"Не удалось найти заметки\n{ex.Message}", MessageBoxIcon.Error);
        }

        return;

        bool SearchPredicate(Note x) {
            // Объединяем заголовок и описание в одну строку
            // чтобы искать по всему тексту
            var fullText = $"{x.Title} {x.Description}";

            // StringComparison.CurrentCultureIgnoreCase - игнорируем регистр
            return keywords.All(kw => fullText.Contains(kw, StringComparison.CurrentCultureIgnoreCase));
        }
    }

    private async void OnLoadNotes() {
        try {
            var notes = await _noteRepository.GetAllAsync();
            _noteView.DisplayNotes(notes.ToList());
        }
        catch (Exception ex) {
            _noteView.DisplayMessage($"Не удалось загрузить заметки\n{ex.Message}", MessageBoxIcon.Error);
        }
    }

    /// <summary>
    ///     Перед открытием новой формы NoteDetails закрывает все другие формы NoteDetails.
    /// </summary>
    private static void CloseOtherForms() {
        var openForms = Application.OpenForms.OfType<NoteDetails>().ToList();
        foreach (var form in openForms) form.Close();
    }
}