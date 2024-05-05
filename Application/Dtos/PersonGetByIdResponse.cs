using Domain.Entities.Primitivies;

namespace Application.Dtos;

public record PersonGetByIdResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string? MiddleName,
    DateTime BirthDay,
    int Age,
    Gender Gender,
    string PhoneNumber,
    string Telegram);