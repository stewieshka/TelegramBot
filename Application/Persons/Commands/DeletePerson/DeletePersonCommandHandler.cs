using Application.Common.Interfaces;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Persons.Commands.DeletePerson;

public class DeletePersonCommandHandler(IPersonRepository personRepository) : IRequestHandler<DeletePersonCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeletePersonCommand command, CancellationToken cancellationToken)
    {
        var person = await personRepository.GetById(command.Id);

        if (person is null)
        {
            return Errors.Person.PersonNotFound;
        }

        personRepository.Delete(person);

        await personRepository.SaveChangesAsync();

        return Result.Deleted;
    }
}