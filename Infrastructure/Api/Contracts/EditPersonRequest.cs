namespace Infrastructure.Api.Contracts;

public record EditPersonRequest(
    string? FirstName, string? LastName, string? MiddleName,
    DateTime? Birthday, int? Gender, string? PhoneNumber, string? Telegram);