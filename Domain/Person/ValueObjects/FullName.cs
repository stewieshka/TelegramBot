using Domain.Common;
using Domain.Common.Errors;
using Domain.Person.ValueObjects;
using ErrorOr;
using static System.String;

namespace Domain.Entities.ValueObjects;

/// <summary>
/// TODO: Описать
/// </summary>
/// <param name="firstName"></param>
/// <param name="lastName"></param>
/// <param name="middleName"></param>
public class FullName : BaseValueObject
{
    private FullName(string firstName, string lastName, string? middleName)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName ?? Empty;
    }

    public static FullName Create(string firstName, string lastName, string? middleName)
    {
        return new FullName(firstName, lastName, middleName);
    }

    public static ErrorOr<FullName> CreateAndValidate(string firstName, string lastName, string? middleName)
    {
        var fullName = new FullName(firstName, lastName, middleName);
        var validator = new FullNameValidator();

        var validationResult = validator.Validate(fullName);

        if (validationResult.IsValid) return fullName;

        var errors = validationResult.Errors
            .ConvertAll(validationFailure => Error.Validation(
                validationFailure.PropertyName, 
                validationFailure.ErrorMessage));

        return errors;
    }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; private set; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; private set; }

    /// <summary>
    /// Второе имя или отчество
    /// </summary>
    public string MiddleName { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return $"{FirstName} {MiddleName} {LastName}";
    }
}