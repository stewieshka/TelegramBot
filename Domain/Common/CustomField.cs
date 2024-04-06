namespace Domain.Common;

/// <summary>
/// Дополнительное поле
/// </summary>
public class CustomField<TValue> : BaseEntity
{
    public CustomField()
    {
        // валидация
    }
    /// <summary>
    /// Название поля
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Значение поля
    /// </summary>
    public TValue Value { get; set; }
}