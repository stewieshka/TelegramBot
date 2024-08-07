using Application.Common.Interfaces;
using Domain.Common.Errors;
using Domain.Entities.ValueObjects;
using Domain.Person;
using Domain.Person.Primitivies;
using ErrorOr;
using MediatR;

namespace Application.Persons.Commands.CreatePerson;

public sealed class CreatePersonCommandHandler(IPersonRepository personRepository) : IRequestHandler<CreatePersonCommand, ErrorOr<Person>>
{
    public async Task<ErrorOr<Person>> Handle(CreatePersonCommand command, CancellationToken cancellationToken)
    {
        var person = Person.Create(
            FullName.Create(command.FirstName, command.LastName, command.MiddleName),
            command.BirthDay, (Gender)command.Gender, command.PhoneNumber, command.Telegram);

        person.CreationDate = DateTime.UtcNow;

        var createdPerson = await personRepository.Add(person);

        await personRepository.SaveChangesAsync();

        return createdPerson;
    }
}