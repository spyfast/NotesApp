namespace Notes.Desktop;

internal static class Program {
    /// <summary>
    ///     Уникальный ID для Mutex.
    /// </summary>
    private const string UniqueId = "NoteApp";

    /// <summary>
    ///     Mutex используется для того, чтобы предотравить запуск приложения более одного раза.
    /// </summary>
    private static Mutex? _mutex;

    /// <summary>
    ///     Флаг, указывающий, является ли текущий экземпляр первым экземпляром приложения.
    /// </summary>
    private static bool _isNewInstance;

    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main() {
        if (!IsSafeExecuted()) {
            MessageBox.Show(@"Приложение уже запущено", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }

        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }

    /// <summary>
    ///     Проверяет, что приложение запущено только один раз.
    /// </summary>
    /// <returns>true, если текущий экземпляр является первым экземпляром приложения</returns>
    private static bool IsSafeExecuted() {
        _mutex ??= new Mutex(true, UniqueId, out _isNewInstance);
        return _isNewInstance;
    }
}