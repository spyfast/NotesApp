using Notes.Models;

namespace Notes.Desktop.Interfaces.Presenters;

/// <summary>
///     Интерфейс, определяющий презентера заметок
/// </summary>
internal interface INotePresenter {
    /// <summary>
    ///     Метод, вызываемый при добавлении новой заметки.
    /// </summary>
    /// <param name="title">Заголовок новой заметки</param>
    /// <param name="description">Опциональное, описание новой заметки</param>
    void OnAddNote(string title, string? description = null);

    /// <summary>
    ///     Метод, вызываемый при удалении заметки.
    /// </summary>
    /// <param name="note">Удаляемая заметка</param>
    void OnDeleteNote(Note note);

    /// <summary>
    ///     Метод, вызываемый при выборе заметки.
    /// </summary>
    /// <param name="note">Выбранная заметка</param>
    void OnSelectNote(Note note);

    /// <summary>
    ///     Метод, вызываемый при поиске заметки.
    /// </summary>
    /// <param name="keyword">Ключевое слово для поиска</param>
    void OnSearchNote(string keyword);
}