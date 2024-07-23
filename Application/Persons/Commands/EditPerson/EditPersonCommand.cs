using ErrorOr;
using MediatR;

namespace Application.Persons.Commands.EditPerson;

public record EditPersonCommand(
    Guid Id, string? FirstName, string? LastName, string? MiddleName,
    DateTime? Birthday, int? Gender, string? PhoneNumber, string? Telegram) : IRequest<ErrorOr<Updated>>;