using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    last_name = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    middle_name = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    phone_number = table.Column<string>(type: "VARCHAR(24)", nullable: false),
                    telegram = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    creation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "custom_fields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    value = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    creation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_custom_fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_custom_fields_persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "persons",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_custom_fields_PersonId",
                table: "custom_fields",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "custom_fields");

            migrationBuilder.DropTable(
                name: "persons");
        }
    }
}
