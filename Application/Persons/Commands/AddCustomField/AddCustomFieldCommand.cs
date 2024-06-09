using ErrorOr;
using MediatR;

namespace Application.Persons.Commands.AddCustomField;

public record AddCustomFieldCommand(
    Guid Id, string Name, string Value) : IRequest<ErrorOr<Success>>;