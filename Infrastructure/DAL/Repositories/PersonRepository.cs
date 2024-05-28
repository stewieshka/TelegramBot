using Application.Common.Interfaces;
using Domain.Common;
using Domain.Person;
using Infrastructure.DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.Repositories;

public class PersonRepository(TelegramBotDbContext context) : IPersonRepository
{
    public async Task<Person?> GetById(Guid id)
    {
        var person = await context.Persons.FindAsync(id);

        return person;
    }

    public async Task<List<Person>> Get(int limit)
    {
        var persons = await context.Persons
            .Take(limit)
            .ToListAsync();

        return persons;
    }

    public async Task<Person> Add(Person person)
    {
        var entityEntry = await context.Persons.AddAsync(person);

        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public Person? Update(Person entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<CustomField<string>> GetCustomFields(Guid id)
    {
        throw new NotImplementedException();
    }
}