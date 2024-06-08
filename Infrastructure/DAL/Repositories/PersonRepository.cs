using Application.Common.Interfaces;
using Domain.Common;
using Domain.Common.Errors;
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

        return entityEntry.Entity;
    }

    public bool Delete(Person person)
    {
        context.Persons.Remove(person);

        return true;
    }

    public List<CustomField<string>> GetCustomFields(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}