using Application.Common.Interfaces;
using Domain.Common;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Persons.Commands.AddCustomField;

public class AddCustomFieldCommandHandler(IPersonRepository personRepository) : IRequestHandler<AddCustomFieldCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(AddCustomFieldCommand command, CancellationToken cancellationToken)
    {
        var person = await personRepository.GetById(command.Id);

        if (person is null)
        {
            return Errors.Person.PersonNotFound;
        }
        
        person.CustomFields.Add(new CustomField<string>(command.Name, command.Value));

        await personRepository.SaveChangesAsync();

        return Result.Success;
    }
}