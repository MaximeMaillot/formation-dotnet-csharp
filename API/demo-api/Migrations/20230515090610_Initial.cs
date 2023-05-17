using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace demo_api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Age", "AvatarUrl", "BirthDate", "FirstName", "FullName", "LastName", "Sexe" },
                values: new object[,]
                {
                    { 1, 29, "", new DateTime(1993, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maxime", "Maxime Maillot", "Maillot", "Male" },
                    { 2, 37, "", new DateTime(1986, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martial", "Martial Maillot", "Maillot", "Male" },
                    { 3, 37, "", new DateTime(1989, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mathilde", "Mathilde Maillot", "Vermuse", "Female" }
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
