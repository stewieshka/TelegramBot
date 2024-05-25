namespace Domain.Common;

/// <summary>
/// Базовый класс для всех сущностей
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Уникальный идентификатор сущности
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Дата создания сущности
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Метод для сравнения сущностей по Id
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        return obj is BaseEntity entity && Id.Equals(entity.Id);
    }

    public static bool operator ==(BaseEntity left, BaseEntity right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(BaseEntity left, BaseEntity right)
    {
        return Equals(left, right);
    }
    
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}