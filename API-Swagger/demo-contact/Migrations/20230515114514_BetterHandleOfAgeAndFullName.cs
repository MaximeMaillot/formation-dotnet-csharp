using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace demo_contact.Migrations
{
    /// <inheritdoc />
    public partial class BetterHandleOfAgeAndFullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "AvatarUrl", "BirthDate", "FirstName", "LastName", "Sexe" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1993, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maxime", "Maillot", "Male" },
                    { 2, null, new DateTime(1986, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martial", "Maillot", "Male" },
                    { 3, null, new DateTime(1989, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mathilde", "Vermuse", "Female" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
