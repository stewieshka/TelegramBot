using Domain.Person;
using ErrorOr;
using MediatR;

namespace Application.Persons.Commands.CreatePerson;

public sealed class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, ErrorOr<Person>>
{
    public async Task<ErrorOr<Person>> Handle(CreatePersonCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var person = Person.Create(command.FirstName, command.LastName,
            command.MiddleName, command.BirthDay, command.Gender, command.PhoneNumber,
            command.Telegram);
        
        throw new NotImplementedException();
    }
}