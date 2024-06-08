﻿// <auto-generated />
using System;
using Infrastructure.DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(TelegramBotDbContext))]
    partial class TelegramBotDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Common.CustomField<string>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("name");

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("custom_fields", (string)null);
                });

            modelBuilder.Entity("Domain.Person.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("DATE")
                        .HasColumnName("birthday");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("creation_date");

                    b.Property<int>("Gender")
                        .HasColumnType("integer")
                        .HasColumnName("gender");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("VARCHAR(24)")
                        .HasColumnName("phone_number");

                    b.Property<string>("Telegram")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("telegram");

                    b.HasKey("Id");

                    b.ToTable("persons", (string)null);
                });

            modelBuilder.Entity("Domain.Common.CustomField<string>", b =>
                {
                    b.HasOne("Domain.Person.Person", null)
                        .WithMany("CustomFields")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("Domain.Person.Person", b =>
                {
                    b.OwnsOne("Domain.Entities.ValueObjects.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("VARCHAR(255)")
                                .HasColumnName("first_name");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("VARCHAR(255)")
                                .HasColumnName("last_name");

                            b1.Property<string>("MiddleName")
                                .IsRequired()
                                .HasColumnType("VARCHAR(255)")
                                .HasColumnName("middle_name");

                            b1.HasKey("PersonId");

                            b1.ToTable("persons");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.Navigation("FullName")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Person.Person", b =>
                {
                    b.Navigation("CustomFields");
                });
#pragma warning restore 612, 618
        }
    }
}
