using FluentValidation;

namespace Application.Persons.Queries.GetPersons;

public class GetPersonsQueryValidator : AbstractValidator<GetPersonsQuery>
{
    public GetPersonsQueryValidator()
    {
        RuleFor(x => x.Limit)
            .Must(BeAValidLimit)
            .WithMessage("Limit must be > 0");
    }

    private bool BeAValidLimit(int limit)
    {
        return limit > 0;
    }
}