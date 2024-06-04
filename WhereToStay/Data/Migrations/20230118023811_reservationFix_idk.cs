using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhereToStay.data.migrations
{
    /// <inheritdoc />
    public partial class reservationFixidk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "HotelRoom",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_ReservationId",
                table: "HotelRoom",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Reservations_ReservationId",
                table: "HotelRoom",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "reservation_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Reservations_ReservationId",
                table: "HotelRoom");

            migrationBuilder.DropIndex(
                name: "IX_HotelRoom_ReservationId",
                table: "HotelRoom");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "HotelRoom");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Reservations",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "room_id");
        }
    }
}
