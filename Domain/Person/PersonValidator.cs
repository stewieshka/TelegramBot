using System.Text.RegularExpressions;
using FluentValidation;

namespace Domain.Person;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(x => x.BirthDay)
            .Must(BeYoungerThan116).WithMessage("You cannot be over 150 years old");

        RuleFor(x => x.PhoneNumber)
            .Must(BeAValidPhoneNumber).WithMessage("Invalid phone number");

        RuleFor(x => x.Telegram)
            .Must(BeAValidTelegram).WithMessage("Invalid telegram");
    }

    private bool BeAValidMiddleName(string middleName)
    {
        if (middleName.Length == 0)
            return true;
        return middleName.Length <= 20;
    }

    private bool BeAName(string name)
    {
        return Regex.IsMatch(name, @"^[a-zA-Zа-яА-Я]+$");
    }

    private bool BeYoungerThan116(DateTime birthDay)
    {
        return DateTime.Now.Year - birthDay.Year <= 150 && birthDay > DateTime.Now;
    }

    private bool BeAValidPhoneNumber(string phoneNumber)
    {
        return Regex.IsMatch(phoneNumber, @"^\+37377[4-9]\d{5}$");
    }

    private bool BeAValidTelegram(string telegram)
    {
        return Regex.IsMatch(telegram, @"^@[a-zA-Z0-9]{3,19}$");
    }
}