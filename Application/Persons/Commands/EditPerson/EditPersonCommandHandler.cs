using Application.Common.Interfaces;
using Domain.Common.Errors;
using Domain.Person.Primitivies;
using ErrorOr;
using MediatR;

namespace Application.Persons.Commands.EditPerson;

public class EditPersonCommandHandler(IPersonRepository personRepository) : IRequestHandler<EditPersonCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(EditPersonCommand command, CancellationToken cancellationToken)
    {
        var person = await personRepository.GetById(command.Id);

        if (person is null)
        {
            return Errors.Person.PersonNotFound;
        }
        
        if (command.FirstName != null)
            person.FullName.FirstName = command.FirstName;

        if (command.LastName != null)
            person.FullName.LastName = command.LastName;

        if (command.MiddleName != null)
            person.FullName.MiddleName = command.MiddleName;

        if (command.Birthday.HasValue)
            person.BirthDay = command.Birthday.Value;

        if (command.Gender != null)
            person.Gender = (Gender)command.Gender;

        if (command.PhoneNumber != null)
            person.PhoneNumber = command.PhoneNumber;

        if (command.Telegram != null)
            person.Telegram = command.Telegram;

        await personRepository.SaveChangesAsync();

        return Result.Updated;
    }
}