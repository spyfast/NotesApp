using Notes.Database;
using Notes.Database.Repositories;
using Notes.Desktop.Interfaces.Presenters;
using Notes.Desktop.Presenters;

namespace Notes.Desktop;

internal partial class MainForm : Form {
    /// <summary>
    ///     Строка подключения к БД.
    /// </summary>
    private const string ConnectionString = "Data Source=notes.db";

    /// <summary>
    ///     Флаг, указывающий, что приложение запущено в режиме разработки.
    /// </summary>
    private const bool IsDevelopment = true;

    public MainForm() {
        InitializeComponent();

        try {
            var dbContext = new DatabaseContext(ConnectionString, IsDevelopment);
            var noteRepository = dbContext.GetRepository<NoteRepository>();

            NotePresenter = new NotePresenter(NoteControl, noteRepository);
        }
        catch (Exception ex) {
            MessageBox.Show($"""
                             Ошибка при инициализации приложения
                             {ex.Message}
                             """, @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public INotePresenter? NotePresenter { get; }
}