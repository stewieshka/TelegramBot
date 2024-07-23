namespace Infrastructure.Api.Contracts.Person;

public record EditPersonRequest(
    string? FirstName, string? LastName, string? MiddleName,
    DateTime? Birthday, int? Gender, string? PhoneNumber, string? Telegram);