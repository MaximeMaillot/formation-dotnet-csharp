using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoHotel.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chambres",
                columns: table => new
                {
                    chambre_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statut = table.Column<int>(type: "int", nullable: false),
                    nb_lit = table.Column<int>(type: "int", nullable: false),
                    tarif = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chambres", x => x.chambre_id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    client_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.client_id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statut = table.Column<int>(type: "int", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false),
                    ChambreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reservations_Chambres_ChambreId",
                        column: x => x.ChambreId,
                        principalTable: "Chambres",
                        principalColumn: "chambre_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Clients_client_id",
                        column: x => x.client_id,
                        principalTable: "Clients",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Chambres",
                columns: new[] { "chambre_id", "nb_lit", "statut", "tarif" },
                values: new object[,]
                {
                    { 1, 2, 0, 32.25m },
                    { 2, 4, 0, 62.25m },
                    { 3, 6, 0, 82.25m },
                    { 4, 3, 0, 52.25m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ChambreId",
                table: "Reservations",
                column: "ChambreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_client_id",
                table: "Reservations",
                column: "client_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Chambres");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
