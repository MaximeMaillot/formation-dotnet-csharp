using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoHotel.Migrations
{
    /// <inheritdoc />
    public partial class ReservationChambre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chambres_Reservations_ReservationId1",
                table: "Chambres");

            migrationBuilder.DropIndex(
                name: "IX_Chambres_ReservationId1",
                table: "Chambres");

            migrationBuilder.DropColumn(
                name: "ReservationId1",
                table: "Chambres");

            migrationBuilder.CreateTable(
                name: "ReservationChambres",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    ChambreId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationChambres", x => new { x.ReservationId, x.ChambreId });
                    table.ForeignKey(
                        name: "FK_ReservationChambres_Chambres_ChambreId",
                        column: x => x.ChambreId,
                        principalTable: "Chambres",
                        principalColumn: "chambre_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationChambres_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationChambres_ChambreId",
                table: "ReservationChambres",
                column: "ChambreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationChambres");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId1",
                table: "Chambres",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Chambres",
                keyColumn: "chambre_id",
                keyValue: 1,
                column: "ReservationId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Chambres",
                keyColumn: "chambre_id",
                keyValue: 2,
                column: "ReservationId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Chambres",
                keyColumn: "chambre_id",
                keyValue: 3,
                column: "ReservationId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Chambres",
                keyColumn: "chambre_id",
                keyValue: 4,
                column: "ReservationId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Chambres_ReservationId1",
                table: "Chambres",
                column: "ReservationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Chambres_Reservations_ReservationId1",
                table: "Chambres",
                column: "ReservationId1",
                principalTable: "Reservations",
                principalColumn: "id");
        }
    }
}
