using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notes.Models;

/// <summary>
///     Модель заметки
/// </summary>
[Table("notes")]
public class Note {
    /// <summary>
    ///     Уникальный идентификатор
    ///     <remarks>Доступ только для чтения</remarks>
    /// </summary>
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    ///     Заголовок заметки
    ///     <exception cref="ValidationException">Выбросит, если не пройдете валидацию</exception>
    /// </summary>
    [Column("title")]
    public string Title { get; set; } = null!;

    /// <summary>
    ///     Описание заметки
    ///     <exception cref="ValidationException">Выбросит, если не пройдете валидацию</exception>
    /// </summary>
    [Column("description")]
    public string? Description { get; set; }

    /// <summary>
    ///     Дата создания заметки
    /// </summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    public IEnumerable<ValidationResult> Validate() {
        if (string.IsNullOrEmpty(Title) || string.IsNullOrWhiteSpace(Title))
            yield return new ValidationResult("Заголовок не может быть пустым", new[] {
                nameof(Title)
            });

        if (Title is { Length: < 2 or > 35 })
            yield return new ValidationResult("Длина заголовка должна быть от 2 до 35 символов", new[] {
                nameof(Title)
            });

        if (string.IsNullOrEmpty(Description) || string.IsNullOrWhiteSpace(Description)) yield break;

        if (Description is { Length: < 3 or > 150 })
            yield return new ValidationResult("Длина описания должна быть от 3 до 150 символов", new[] {
                nameof(Description)
            });
    }
}