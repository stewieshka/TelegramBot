using Application.Common.Interfaces;
using Domain.Common.Errors;
using Domain.Person;
using ErrorOr;
using MediatR;

namespace Application.Persons.Queries.GetPerson;

public class GetPersonQueryHandler(IPersonRepository personRepository) : IRequestHandler<GetPersonQuery, ErrorOr<Person>>
{
    public async Task<ErrorOr<Person>> Handle(GetPersonQuery query, CancellationToken cancellationToken)
    {
        var person = await personRepository.GetById(query.Id);

        if (person is null)
        {
            return Errors.Person.PersonNotFound;
        }

        return person;
    }
}