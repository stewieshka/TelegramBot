using ErrorOr;
using MediatR;

namespace Application.Persons.Commands.DeletePerson;

public record DeletePersonCommand(
    Guid Id) : IRequest<ErrorOr<Deleted>>;