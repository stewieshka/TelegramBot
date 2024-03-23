using System.Text.RegularExpressions;
using Domain.Common;
using Domain.Common.Errors;
using Domain.Entities;
using Domain.Entities.Primitivies;
using Domain.Entities.ValueObjects;
using ErrorOr;

namespace Domain.Person;

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
    
    public FullName FullName { get; private set; }
    
    // не старше 116
    public DateTime BirthDay { get; private set; }

    public int Age => DateTime.Now.Year - BirthDay.Year;
    
    public Gender Gender { get; private set; }
    
    // +373 77(456789) 12345
    public string PhoneNumber { get; private set; }
    
    // есть собачка, ник не больше 20 символов
    public string Telegram { get; private set; }
    
}