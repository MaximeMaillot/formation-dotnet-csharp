using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoHotel.Migrations
{
    /// <inheritdoc />
    public partial class OneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Chambres_chambre_id",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_chambre_id",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "chambre_id",
                table: "Reservations");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "chambre_id",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_chambre_id",
                table: "Reservations",
                column: "chambre_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Chambres_chambre_id",
                table: "Reservations",
                column: "chambre_id",
                principalTable: "Chambres",
                principalColumn: "chambre_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
