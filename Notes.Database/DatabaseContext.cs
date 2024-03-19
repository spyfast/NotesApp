using Microsoft.EntityFrameworkCore;
using Notes.Models;

namespace Notes.Database;

/// <summary>
///     Контекст базы данных.
/// </summary>
public sealed class DatabaseContext : DbContext {
    private readonly string _connection;
    private readonly bool _isDevelopment;
    private Dictionary<Type, object>? _repositories;

    /// <summary>
    ///     Инициализация контекста базы данных.
    /// </summary>
    /// <param name="connection">Строка подключения к БД</param>
    /// <param name="isDevelopment">Если true, существующая БД будет удалена перед созданием новой</param>
    public DatabaseContext(string connection, bool isDevelopment) {
        _connection = connection;
        _isDevelopment = isDevelopment;

        _repositories = new Dictionary<Type, object>();
        Notes = Set<Note>();

        if (isDevelopment) Database.EnsureDeleted();

        Database.EnsureCreated();
    }

    /// <summary>
    ///     Заметки в БД.
    /// </summary>
    public DbSet<Note> Notes { get; }

    /// <summary>
    ///     Настройка параметров контекста БД.
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        var builder = optionsBuilder.UseSqlite(_connection);

        if (_isDevelopment) builder.EnableSensitiveDataLogging().LogTo(Console.WriteLine);
    }

    /// <summary>
    ///     Получает репозиторий указанного типа TEntity. Если репозиторий уже существует, возвращает его.
    ///     В противном случае создает новый экземпляр репозитория и добавляет его в словарь.
    /// </summary>
    /// <typeparam name="TEntity">Тип репозитория</typeparam>
    /// <returns>Экземпляр репозитория указанного типа TEntity</returns>
    /// <exception cref="InvalidOperationException">Выбрасывается, если не удалось создать экземпляр репозитория</exception>
    public TEntity GetRepository<TEntity>() where TEntity : class {
        _repositories ??= new Dictionary<Type, object>();

        try {
            var type = typeof(TEntity);
            // Проверяем, существует ли уже репозиторий данного типа в словаре
            if (_repositories.TryGetValue(type, out var value)) return (value as TEntity)!;

            // Создаем новый экземпляр репозитория и добавляем его в словарь
            value = Activator.CreateInstance(type, this)!;
            _repositories[type] = value;

            return (value as TEntity)!;
        }
        catch {
            // Если не удалось создать экземпляр репозитория, выбрасываем исключение
            throw new InvalidOperationException("Репозиторий не найден");
        }
    }
}