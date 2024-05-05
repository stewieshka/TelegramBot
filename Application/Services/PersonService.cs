using Application.Common.Interfaces;
using Application.Dtos;
using Application.Mapping;
using Domain.Common.Errors;
using ErrorOr;

namespace Application.Services;

public class PersonService
{
    // TODO: добавить сюда методы, добавить маппинг
    
    private readonly IPersonRepository _personRepository;
    private readonly PersonMapper _personMapper;

    public PersonService(IPersonRepository personRepository, PersonMapper personMapper)
    {
        _personRepository = personRepository;
        _personMapper = personMapper;
    }

    public ErrorOr<PersonGetByIdResponse> GetById(Guid id)
    {
        var person = _personRepository.GetById(id);
        
        if (person is null)
        {
            return Errors.Person.PersonNotFound;
        }
        
        var response = _personMapper.PersonToGetByIdDto(person);
        
        return response;
    }

    public PersonCreateResponse Create(PersonCreateRequest personCreateRequest)
    {
        var person = _personMapper.PersonCreateDtoToPerson(personCreateRequest);
        var createdPerson = _personRepository.Add(person);
        var response = _personMapper.PersonToPersonCreateResponse(createdPerson);
        return response;
    }

    public void Delete(Guid id)
    {
        _personRepository.Delete(id);
    }
}