using Application.Dtos;
using Domain.Person;
using Riok.Mapperly.Abstractions;

namespace Application.Mapping;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
public partial class PersonMapper
{
    [MapProperty(nameof(Person.FullName.FirstName), nameof(PersonGetByIdResponse.FirstName))]
    [MapProperty(nameof(Person.FullName.LastName), nameof(PersonGetByIdResponse.LastName))]
    [MapProperty(nameof(Person.FullName.MiddleName), nameof(PersonGetByIdResponse.MiddleName))]
    public partial PersonGetByIdResponse PersonToGetByIdDto(Person person);

    [MapProperty(nameof(PersonCreateRequest.FirstName), nameof(Person.FullName.FirstName))]
    [MapProperty(nameof(PersonCreateRequest.LastName), nameof(Person.FullName.LastName))]
    [MapProperty(nameof(PersonCreateRequest.MiddleName), nameof(Person.FullName.MiddleName))]
    public partial Person PersonCreateDtoToPerson(PersonCreateRequest dto);

    public partial PersonCreateResponse PersonToPersonCreateResponse(Person person);
}