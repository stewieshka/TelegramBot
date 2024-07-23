using FluentValidation;

namespace Application.Persons.Commands.EditPerson;

public class EditPersonCommandValidator : AbstractValidator<EditPersonCommand>
{
    public EditPersonCommandValidator()
    {
        When(x => x.FirstName != null, () =>
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(20)
                .Matches("^[a-zA-Zа-яА-Я]+$")
                .WithMessage("First name must consist of letters only");
        });

        When(x => x.LastName != null, () =>
        {
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(20)
                .Matches("^[a-zA-Zа-яА-Я]+$")
                .WithMessage("Last name must consist of letters only");
        });

        When(x => x.MiddleName != null, () =>
        {
            RuleFor(x => x.MiddleName)
                .Must(BeAValidMiddleName)
                .WithMessage("Invalid middle name");
        });

        When(x => x.Birthday != null, () =>
        {
            RuleFor(x => x.Birthday)
                .Must(BeYoungerThan150)
                .WithMessage("You cannot be over 150 years old");
        });

        When(x => x.PhoneNumber != null, () =>
        {
            RuleFor(x => x.PhoneNumber)
                .Matches("^\\+37377[4-9]\\d{5}$")
                .WithMessage("Invalid phone number");
        });

        When(x => x.Telegram != null, () =>
        {
            RuleFor(x => x.Telegram)
                .Matches("^@[a-zA-Z0-9]{3,19}$")
                .WithMessage("Invalid telegram");
        });

        When(x => x.Gender != null, () =>
        {
            RuleFor(x => x.Gender)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(2)
                .WithMessage("Gender code must be 0, 1 or 2");
        });
    }

    private bool BeAValidMiddleName(string? middleName)
    {
        if (middleName is { Length: 0 })
            return true;
        return middleName is { Length: <= 20 };
    }
    
    private bool BeYoungerThan150(DateTime? birthDay)
    {
        return DateTime.Now.Year - birthDay!.Value.Year <= 150 && birthDay < DateTime.Now;
    }
}