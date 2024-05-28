using System.Text.Json.Serialization;
using Infrastructure.Api.Common;

namespace Infrastructure.Api.Contracts;

public record CreatePersonRequest(
    string FirstName, string LastName, string? MiddleName,
    [property: JsonConverter(typeof(CustomDateTimeConverter))] DateTime BirthDay,
    string Gender, string PhoneNumber, string Telegram);