using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.EntityFramework.Configurations;

/// <summary>
/// Конфигурация Fluent Api для CustomField
/// </summary>
public class CustomFieldConfiguration : IEntityTypeConfiguration<CustomField<string>>
{
    public void Configure(EntityTypeBuilder<CustomField<string>> builder)
    {
        builder.ToTable("custom_fields");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreationDate)
            .HasColumnName("creation_date")
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("VARCHAR(255)")
            .IsRequired();

        builder.Property(x => x.Value)
            .HasColumnName("value")
            .HasColumnType("VARCHAR(255)")
            .IsRequired();
    }
}