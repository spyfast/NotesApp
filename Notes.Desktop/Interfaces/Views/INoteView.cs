using Notes.Models;

namespace Notes.Desktop.Interfaces.Views;

/// <summary>
///     Интерфейс, определяющий представление заметок.
/// </summary>
internal interface INoteView {
    /// <summary>
    ///     Событие, вызываемое при загрузке заметок.
    /// </summary>
    event Action LoadNotes;

    /// <summary>
    ///     Событие, вызываемое при добавлении новой заметки.
    /// </summary>
    event Action<string, string?> AddNote;

    /// <summary>
    ///     Событие, вызываемое при удалении заметки.
    /// </summary>
    event Action<Note> DeleteNote;

    /// <summary>
    ///     Событие, вызываемое при выборе заметки.
    /// </summary>
    event Action<Note> SelectNote;

    /// <summary>
    ///     Событие, вызываемое при поиске заметки.
    /// </summary>
    event Action<string> SearchNote;

    /// <summary>
    ///     Метод для отображения списка заметок.
    /// </summary>
    /// <param name="notes">Список заметок для отображения</param>
    void DisplayNotes(List<Note> notes);

    /// <summary>
    ///     Метод для отображения логов.
    /// </summary>
    /// <param name="message">Сообщение для отображения</param>
    /// <param name="icon">Иконка сообщения</param>
    void DisplayMessage(string message, MessageBoxIcon icon = MessageBoxIcon.Information);

    /// <summary>
    ///     Метод для очистки ввода заметки.
    /// </summary>
    void ClearNoteInput();
}