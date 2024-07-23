using Domain.Person;
using MediatR;

namespace Application.Persons.Queries.GetPersonsWhoseBirthday;

public record GetPersonsWhoseBirthdayQuery(DateTime Date): IRequest<List<Person>>;