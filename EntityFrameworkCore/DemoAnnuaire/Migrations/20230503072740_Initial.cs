using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoAnnuaire.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroVoie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplementAdresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntituleVoie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Commune = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodePostal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresses");
        }
    }
}
