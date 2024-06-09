using Domain.Common;
using Domain.Person;

namespace Application.Common.Interfaces;

public interface IPersonRepository : IRepository<Person>
{
    public Task<List<CustomField<string>>> GetCustomFields(Guid id);
}