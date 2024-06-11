using Application.Common.Interfaces;
using Domain.Person;
using MediatR;

namespace Application.Persons.Queries.GetPersonsWhoseBirthday;

public class GetPersonsWhoseBirthdayQueryHandler(IPersonRepository personRepository) : IRequestHandler<GetPersonsWhoseBirthdayQuery, List<Person>>
{
    public async Task<List<Person>> Handle(GetPersonsWhoseBirthdayQuery query, CancellationToken cancellationToken)
    {
        var persons = await personRepository.GetPersonsWhoseBirthday(query.Date);

        return persons;
    }
}