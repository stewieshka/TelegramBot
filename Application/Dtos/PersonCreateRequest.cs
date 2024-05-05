namespace Application.Dtos;

public record PersonCreateRequest(
    string FirstName,
    string LastName,
    string MiddleName,
    DateTime BirthDay,
    string Gender,
    string PhoneNumber,
    string Telegram);