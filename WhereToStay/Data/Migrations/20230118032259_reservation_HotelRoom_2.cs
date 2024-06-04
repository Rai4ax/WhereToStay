using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhereToStay.data.migrations
{
    /// <inheritdoc />
    public partial class reservationHotelRoom2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Reservations_reservation_id",
                table: "HotelRoom");

            migrationBuilder.DropIndex(
                name: "IX_HotelRoom_reservation_id",
                table: "HotelRoom");

            migrationBuilder.DropColumn(
                name: "reservation_id",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "reservation_id",
                table: "HotelRoom",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_reservation_id",
                table: "HotelRoom",
                column: "reservation_id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Reservations_reservation_id",
                table: "HotelRoom",
                column: "reservation_id",
                principalTable: "Reservations",
                principalColumn: "reservation_id");
        }
    }
}
