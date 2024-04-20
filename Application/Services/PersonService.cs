using Application.Common.Interfaces;

namespace Application.Services;

public class PersonService
{
    // TODO: добавить сюда методы, добавить маппинг
    
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    
    
}