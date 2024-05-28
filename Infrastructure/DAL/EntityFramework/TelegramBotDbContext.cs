using Domain.Common;
using Domain.Person;
using Infrastructure.DAL.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL.EntityFramework;

public class TelegramBotDbContext(DbContextOptions<TelegramBotDbContext> options) : DbContext(options)
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<CustomField<string>> CustomFields { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TelegramBotDbContext).Assembly);
    }
}