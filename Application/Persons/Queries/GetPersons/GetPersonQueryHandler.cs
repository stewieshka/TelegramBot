using Application.Common.Interfaces;
using Domain.Person;
using MediatR;
using ErrorOr;

namespace Application.Persons.Queries.GetPersons;

public class GetPersonQueryHandler(IPersonRepository personRepository) : IRequestHandler<GetPersonsQuery, ErrorOr<List<Person>>>
{
    public async Task<ErrorOr<List<Person>>> Handle(GetPersonsQuery query, CancellationToken cancellationToken)
    {
        var persons = await personRepository.Get(query.Limit);

        return persons;
    }
}