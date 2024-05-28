using Domain.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.EntityFramework.Configurations;

/// <summary>
/// Конфигурация Fluent Api для Person
/// </summary>
public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("persons");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.CreationDate)
            .HasColumnName("creation_date")
            .IsRequired();

        builder.OwnsOne(x => x.FullName, fullName =>
        {
            fullName.Property(x => x.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("VARCHAR(255)")
                .IsRequired();
            
            fullName.Property(x => x.LastName)
                .HasColumnName("last_name")
                .HasColumnType("VARCHAR(255)")
                .IsRequired();
            
            fullName.Property(x => x.MiddleName)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("middle_name");
        });

        builder.Property(x => x.BirthDay)
            .HasColumnName("birthday")
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .HasColumnName("phone_number")
            .HasColumnType("VARCHAR(24)")
            .IsRequired();

        builder.Property(x => x.Telegram)
            .HasColumnName("telegram")
            .HasColumnType("VARCHAR(255)")
            .IsRequired();

        builder.Property(x => x.Gender)
            .HasColumnName("gender")
            .IsRequired();
    }
}