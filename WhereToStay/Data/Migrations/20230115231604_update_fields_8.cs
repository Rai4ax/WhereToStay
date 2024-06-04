using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhereToStay.data.migrations
{
    /// <inheritdoc />
    public partial class updatefields8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Hotels_rooms_hotel_id",
                table: "HotelRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Rooms_hotelR_room_id",
                table: "HotelRoom");

            migrationBuilder.RenameColumn(
                name: "rooms_hotel_id",
                table: "HotelRoom",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "hotelR_room_id",
                table: "HotelRoom",
                newName: "HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRoom_rooms_hotel_id",
                table: "HotelRoom",
                newName: "IX_HotelRoom_RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Hotels_HotelId",
                table: "HotelRoom",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "hotel_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Rooms_RoomId",
                table: "HotelRoom",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "room_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Hotels_HotelId",
                table: "HotelRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Rooms_RoomId",
                table: "HotelRoom");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "HotelRoom",
                newName: "rooms_hotel_id");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "HotelRoom",
                newName: "hotelR_room_id");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRoom_RoomId",
                table: "HotelRoom",
                newName: "IX_HotelRoom_rooms_hotel_id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Hotels_rooms_hotel_id",
                table: "HotelRoom",
                column: "rooms_hotel_id",
                principalTable: "Hotels",
                principalColumn: "hotel_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Rooms_hotelR_room_id",
                table: "HotelRoom",
                column: "hotelR_room_id",
                principalTable: "Rooms",
                principalColumn: "room_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
