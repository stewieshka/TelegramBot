using System.Text.RegularExpressions;
using Domain.Entities.ValueObjects;
using FluentValidation;

namespace Domain.Person.ValueObjects;

public class FullNameValidator : AbstractValidator<FullName>
{
    public FullNameValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(20)
            .Must(BeAName).WithMessage("First name must consist of letters only");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(20)
            .Must(BeAName).WithMessage("Last name must consist of letters only");

        RuleFor(x => x.MiddleName)
            .Must(BeAValidMiddleName).WithMessage("Invalid middle name");
    }
    
    private static bool BeAValidMiddleName(string middleName)
    {
        if (middleName.Length == 0)
            return true;
        return middleName.Length <= 20;
    }

    private static bool BeAName(string name)
    {
        return Regex.IsMatch(name, @"^[a-zA-Zа-яА-Я]+$");
    }
}