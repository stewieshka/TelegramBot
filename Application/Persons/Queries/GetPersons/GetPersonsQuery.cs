using Domain.Person;
using ErrorOr;
using MediatR;

namespace Application.Persons.Queries.GetPersons;

public record GetPersonsQuery(int Limit) : IRequest<ErrorOr<List<Person>>>;