using Domain.Person;
using ErrorOr;
using MediatR;

namespace Application.Persons.Queries.GetPerson;

public record GetPersonQuery(Guid Id) : IRequest<ErrorOr<Person>>;