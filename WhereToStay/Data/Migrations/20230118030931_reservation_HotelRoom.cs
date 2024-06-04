using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhereToStay.data.migrations
{
    /// <inheritdoc />
    public partial class reservationHotelRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Reservations_ReservationId",
                table: "HotelRoom");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "HotelRoom",
                newName: "reservation_id");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRoom_ReservationId",
                table: "HotelRoom",
                newName: "IX_HotelRoom_reservation_id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Reservations_reservation_id",
                table: "HotelRoom",
                column: "reservation_id",
                principalTable: "Reservations",
                principalColumn: "reservation_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Reservations_reservation_id",
                table: "HotelRoom");

            migrationBuilder.RenameColumn(
                name: "reservation_id",
                table: "HotelRoom",
                newName: "ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRoom_reservation_id",
                table: "HotelRoom",
                newName: "IX_HotelRoom_ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Reservations_ReservationId",
                table: "HotelRoom",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "reservation_id");
        }
    }
}
