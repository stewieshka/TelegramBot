using Domain.Common;

namespace Domain.Entities.ValueObjects;

/// <summary>
/// TODO: Описать
/// </summary>
/// <param name="firstName"></param>
/// <param name="lastName"></param>
/// <param name="middleName"></param>
public class FullName(string firstName, string lastName, string? middleName) : BaseValueObject
{
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; private set; } = firstName;
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; private set; } = lastName;

    /// <summary>
    /// Второе имя или отчество
    /// </summary>
    public string? MiddleName { get; private set; } = middleName;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return $"{FirstName} {MiddleName} {LastName}";
    }
}