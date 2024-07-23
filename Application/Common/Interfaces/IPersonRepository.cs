using Domain.Common;
using Domain.Person;

namespace Application.Common.Interfaces;

public interface IPersonRepository : IRepository<Person>
{
    public Task<List<CustomField<string>>> GetCustomFields(Guid id);

    public Task<List<Person>> GetPersonsWhoseBirthday(DateTime date);
}