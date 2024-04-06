using System.Text.RegularExpressions;
using Domain.Common;
using Domain.Common.Errors;
using Domain.Entities;
using Domain.Entities.Primitivies;
using Domain.Entities.ValueObjects;
using ErrorOr;

namespace Domain.Person;


// TODO: Провалидировать все поля

/// <summary>
/// Основная сущность персоны
/// </summary>
public class Person : BaseEntity
{
    private Person(FullName fullName, DateTime birthDay, Gender gender, string phoneNumber, string telegram)
    {
        FullName = fullName;
        BirthDay = birthDay;
        Gender = gender;
        PhoneNumber = phoneNumber;
        Telegram = telegram;
        // TODO: * FluentValidation
    }

    public static ErrorOr<Person> Create(string firstName, string lastName, string middleName, DateTime birthDay, Gender gender, string phoneNumber, string telegram)
    {
        return new Person(new FullName(firstName, lastName, middleName),
                            birthDay,
                            gender, 
                            phoneNumber, 
                            telegram);
    }
    
    /// <summary>
    /// Полное имя
    /// </summary>
    public FullName FullName { get; private set; }

    /// <summary>
    /// День рождения
    /// </summary>
    public DateTime BirthDay { get; private set; }

    /// <summary>
    /// Возраст
    /// </summary>
    public int Age => DateTime.Now.Year - BirthDay.Year;
    
    /// <summary>
    /// Пол
    /// </summary>
    public Gender Gender { get; private set; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; private set; }
    
    /// <summary>
    /// Телеграм
    /// </summary>
    public string Telegram { get; private set; }
    
    /// <summary>
    /// Дополнительные поля
    /// </summary>
    public List<CustomField<string>> CustomFields { get; set; }
}