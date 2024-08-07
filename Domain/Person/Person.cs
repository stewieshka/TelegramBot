using Domain.Common;
using Domain.Entities.ValueObjects;
using Domain.Person.Primitivies;
using ErrorOr;

namespace Domain.Person;

/// <summary>
/// Основная сущность персоны
/// </summary>
public class Person : BaseEntity
{
    // Для EF
    public Person()
    {
        
    }
    
    private Person(FullName fullName, DateTime birthDay, Gender gender, string phoneNumber, string telegram)
    {
        FullName = fullName;
        BirthDay = birthDay;
        Gender = gender;
        PhoneNumber = phoneNumber;
        Telegram = telegram;
    }

    /// <summary>
    /// Статический метод для создания модели без валидации
    /// </summary>
    /// <param name="fullName"></param>
    /// <param name="birthDay"></param>
    /// <param name="gender"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="telegram"></param>
    /// <returns></returns>
    public static Person Create(FullName fullName, DateTime birthDay, Gender gender, string phoneNumber, string telegram)
    {
        return new Person(fullName,
                            birthDay,
                            gender, 
                            phoneNumber, 
                            telegram);
    }
    
    public static Person Create(FullName fullName, DateTime birthDay, string genderString, string phoneNumber, string telegram)
    {
        return new Person(fullName,
            birthDay,
            Enum.TryParse<Gender>(genderString, out var gender) ? gender : Gender.Undefined, 
            phoneNumber, 
            telegram);
    }

    /// <summary>
    /// Статический метод для создания и валидации модели
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="middleName"></param>
    /// <param name="birthDay"></param>
    /// <param name="gender"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="telegram"></param>
    /// <returns></returns>
    public static ErrorOr<Person> CreateAndValidate(string firstName, string lastName, string middleName, DateTime birthDay, Gender gender, string phoneNumber, string telegram)
    {
        var fullName = FullName.CreateAndValidate(firstName, lastName, middleName);

        var person = new Person(fullName.Value, birthDay, gender, phoneNumber, telegram);

        var validator = new PersonValidator();

        var validationResult = validator.Validate(person);

        if (!fullName.IsError && validationResult.IsValid)
        {
            return person;
        }
        
        var errors = validationResult.Errors
            .ConvertAll(validationFailure => Error.Validation(
                validationFailure.PropertyName, 
                validationFailure.ErrorMessage));

        errors.AddRange(fullName.Errors);

        return errors;
    }

    /// <summary>
    /// Полное имя
    /// </summary>
    public FullName FullName { get; set; }

    /// <summary>
    /// День рождения
    /// </summary>
    public DateTime BirthDay { get; set; }

    /// <summary>
    /// Возраст
    /// </summary>
    public int Age => DateTime.Now.Year - BirthDay.Year;
    
    /// <summary>
    /// Пол
    /// </summary>
    public Gender Gender { get; set; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; set; }
    
    /// <summary>
    /// Телеграм
    /// </summary>
    public string Telegram { get; set; }

    /// <summary>
    /// Дополнительные поля
    /// </summary>
    public List<CustomField<string>> CustomFields { get; set; } = [];
}