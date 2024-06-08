namespace Infrastructure.Api.Contracts;

public record CreatePersonRequest(
    string FirstName, string LastName, string? MiddleName,
    DateTime BirthDay,
    int Gender, string PhoneNumber, string Telegram);