using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoHotel.Migrations
{
    /// <inheritdoc />
    public partial class RenameReservationForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Chambres_ChambreId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ChambreId",
                table: "Reservations",
                newName: "chambre_id");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ChambreId",
                table: "Reservations",
                newName: "IX_Reservations_chambre_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Chambres_chambre_id",
                table: "Reservations",
                column: "chambre_id",
                principalTable: "Chambres",
                principalColumn: "chambre_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Chambres_chambre_id",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "chambre_id",
                table: "Reservations",
                newName: "ChambreId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_chambre_id",
                table: "Reservations",
                newName: "IX_Reservations_ChambreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Chambres_ChambreId",
                table: "Reservations",
                column: "ChambreId",
                principalTable: "Chambres",
                principalColumn: "chambre_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
