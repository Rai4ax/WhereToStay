using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhereToStay.data.migrations
{
    /// <inheritdoc />
    public partial class reservationFix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_room_id",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "room_id",
                table: "Reservations",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_room_id",
                table: "Reservations",
                newName: "IX_Reservations_RoomId");

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

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Reservations",
                newName: "room_id");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                newName: "IX_Reservations_room_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_room_id",
                table: "Reservations",
                column: "room_id",
                principalTable: "Rooms",
                principalColumn: "room_id");
        }
    }
}
