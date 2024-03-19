namespace Notes.Database.Interfaces;

/// <summary>
///     Интерфейс репозитория.
/// </summary>
/// <typeparam name="TEntity">Тип объекта, с которым работает репозиторий</typeparam>
public interface IRepository<TEntity> where TEntity : class {
    /// <summary>
    ///     Получить все объекты типа <typeparamref name="TEntity" />.
    /// </summary>
    /// <returns>Перечисление всех объектов типа <typeparamref name="TEntity" /></returns>
    Task<IEnumerable<TEntity>> GetAllAsync();

    /// <summary>
    ///     Получить объект типа <typeparamref name="TEntity" /> по его идентификатору.
    /// </summary>
    /// <param name="id">ID объекта</param>
    /// <returns>Объект типа <typeparamref name="TEntity" /> с указанным ID</returns>
    /// <remarks>Если в БД нет, то вернет null</remarks>
    Task<TEntity?> GetAsync(int id);

    /// <summary>
    ///     Создание нового объекта типа <typeparamref name="TEntity" />.
    /// </summary>
    /// <param name="item">Новый объект для создания</param>
    Task CreateAsync(TEntity item);

    /// <summary>
    ///     Удаление объекта типа <typeparamref name="TEntity" /> по его идентификатору.
    /// </summary>
    /// <param name="item">Объект для удаления</param>
    Task<bool> DeleteAsync(TEntity item);
}