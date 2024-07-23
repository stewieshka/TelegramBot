namespace Infrastructure.Api.Contracts.Person;

public record AddCustomFieldRequest(
    string Name, string Value);