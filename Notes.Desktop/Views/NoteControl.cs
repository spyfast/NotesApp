using Notes.Desktop.Interfaces.Views;
using Notes.Models;

namespace Notes.Desktop.Views;

internal partial class NoteControl : UserControl, INoteView {
    public NoteControl() {
        InitializeComponent();
    }

    public event Action? LoadNotes;
    public event Action<string, string>? AddNote;
    public event Action<Note>? DeleteNote;
    public event Action<Note>? SelectNote;
    public event Action<string>? SearchNote;

    public void DisplayNotes(List<Note> notes) {
        var sortedNotes = notes.OrderByDescending(x => x.CreatedAt);

        NoteListBox.Items.Clear();
        NoteListBox.Items.AddRange(sortedNotes.Select(x => x as object).ToArray());
    }

    public void DisplayMessage(string message, MessageBoxIcon icon = MessageBoxIcon.Asterisk) {
        MessageBox.Show(message, @"Уведомление", MessageBoxButtons.OK, icon);
    }

    public void ClearNoteInput() {
        TitleTextBox.Text = string.Empty;
        DescriptionBox.Text = string.Empty;
    }

    public void DisplayNoteDetails(Note note) {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Грузим в листбокс заметки при загрузке вьюхи
    /// </summary>
    private void NoteControl_Load(object sender, EventArgs e) {
        LoadNotes?.Invoke();
    }

    private void CreateNoteBtn_Click(object sender, EventArgs e) {
        var title = TitleTextBox.Text;
        var description = DescriptionBox.Text;

        AddNote?.Invoke(title, description);
    }

    /// <summary>
    /// Дефолтное удаление заметки через кнопку
    /// </summary>
    private void RemoveNoteBtn_Click(object sender, EventArgs e) {
        if (NoteListBox.SelectedItem is null) {
            DisplayMessage("Ну а кого удалять-то?", MessageBoxIcon.Warning);
            return;
        }

        var index = NoteListBox.SelectedIndex;
        if (index == -1) {
            DisplayMessage("Выберите заметку для удаления", MessageBoxIcon.Warning);
            return;
        }

        var note = (NoteListBox.Items[index] as Note)!;
        DeleteNote?.Invoke(note);
    }

    /// <summary>
    /// Можем удалить заметку, нажав клавишу Delete
    /// </summary>
    private void NoteListBox_KeyDown(object sender, KeyEventArgs e) {
        if (e.KeyCode == Keys.Delete) RemoveNoteBtn_Click(sender, e);
    }

    /// <summary>
    /// Открываем заметку для просмотра, дважды кликнув по ней
    /// </summary>
    private void NoteListBox_DoubleClick(object sender, EventArgs e) {
        if (NoteListBox.SelectedItem is null) {
            DisplayMessage("Ну а кого просматривать-то?", MessageBoxIcon.Warning);
            return;
        }

        var index = NoteListBox.SelectedIndex;
        if (index == -1) {
            DisplayMessage("Выберите заметку для просмотра", MessageBoxIcon.Warning);
            return;
        }

        var note = (NoteListBox.Items[index] as Note)!;
        SelectNote?.Invoke(note);
    }

    private void SearchQueryTextBox_TextChanged(object sender, EventArgs e) {
        SearchNote?.Invoke(SearchQueryTextBox.Text.ToLower());
    }
}