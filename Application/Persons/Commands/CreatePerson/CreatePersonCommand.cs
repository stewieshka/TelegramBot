using Domain.Entities.Primitivies;
using Domain.Person;
using MediatR;
using ErrorOr;

namespace Application.Persons.Commands.CreatePerson;

public sealed record CreatePersonCommand(string FirstName, string LastName, 
    string? MiddleName, DateTime BirthDay, string Gender, 
    string PhoneNumber, string Telegram) : IRequest<ErrorOr<Person>>;