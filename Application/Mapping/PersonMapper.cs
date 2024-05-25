using Application.Dtos;
using Domain.Entities.Primitivies;
using Domain.Entities.ValueObjects;
using Domain.Person;
using Riok.Mapperly.Abstractions;

namespace Application.Mapping;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
public partial class PersonMapper
{
    // [MapProperty(nameof(Person.Id), nameof(PersonGetByIdResponse.Id))]
    // [MapProperty(nameof(Person.FullName.FirstName), nameof(PersonGetByIdResponse.FirstName))]
    // [MapProperty(nameof(Person.FullName.LastName), nameof(PersonGetByIdResponse.LastName))]
    // [MapProperty(nameof(Person.FullName.MiddleName), nameof(PersonGetByIdResponse.MiddleName))]
    // [MapProperty(nameof(Person.BirthDay), nameof(PersonGetByIdResponse.BirthDay))]
    // [MapProperty(nameof(Person.Gender), nameof(PersonGetByIdResponse.Gender))]
    // [MapProperty(nameof(Person.PhoneNumber), nameof(PersonGetByIdResponse.PhoneNumber))]
    // [MapProperty(nameof(Person.Telegram), nameof(PersonGetByIdResponse.Telegram))]
    // public partial PersonGetByIdResponse PersonToGetByIdDto(Person person);
    public PersonGetByIdResponse PersonToGetByIdDto(Person person)
    {
        return new PersonGetByIdResponse(
            person.Id, person.FullName.FirstName, person.FullName.LastName, person.FullName.MiddleName,
            person.BirthDay, person.Age, person.Gender, person.PhoneNumber, person.Telegram);
    }

    // [MapProperty(nameof(PersonCreateRequest.FirstName), nameof(Person.FullName.FirstName))]
    // [MapProperty(nameof(PersonCreateRequest.LastName), nameof(Person.FullName.LastName))]
    // [MapProperty(nameof(PersonCreateRequest.MiddleName), nameof(Person.FullName.MiddleName))]
    // public partial Person PersonCreateDtoToPerson(PersonCreateRequest dto);

    public Person PersonCreateDtoToPerson(PersonCreateRequest dto)
    {
        return Person.Create(FullName.Create(dto.FirstName, dto.LastName, dto.MiddleName),
            dto.BirthDay, dto.Gender,
            dto.PhoneNumber, dto.Telegram);
    }

    public partial PersonCreateResponse PersonToPersonCreateResponse(Person person);
}