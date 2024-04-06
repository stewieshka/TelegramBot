using Domain.Common;
using Domain.Person;

namespace Application.Common.Interfaces;

public interface IPersonRepository : IRepository<Person>
{
    public List<CustomField<string>> GetCustomFields(Guid id);
}