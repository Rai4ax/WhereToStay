using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhereToStay.data.migrations
{
    /// <inheritdoc />
    public partial class updatefields6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelImage_Hotels_Img_HotelIDhotel_id",
                table: "HotelImage");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelImage_Images_Hotel_ImgIDimage_id",
                table: "HotelImage");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Hotels_RoomsHotelIDhotel_id",
                table: "HotelRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Rooms_HotelRoomIDroom_id",
                table: "HotelRoom");

            migrationBuilder.RenameColumn(
                name: "RoomsHotelIDhotel_id",
                table: "HotelRoom",
                newName: "rooms_hotel_id");

            migrationBuilder.RenameColumn(
                name: "HotelRoomIDroom_id",
                table: "HotelRoom",
                newName: "hotelR_room_id");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRoom_RoomsHotelIDhotel_id",
                table: "HotelRoom",
                newName: "IX_HotelRoom_rooms_hotel_id");

            migrationBuilder.RenameColumn(
                name: "Img_HotelIDhotel_id",
                table: "HotelImage",
                newName: "img_hotel_id");

            migrationBuilder.RenameColumn(
                name: "Hotel_ImgIDimage_id",
                table: "HotelImage",
                newName: "hotel_image_id");

            migrationBuilder.RenameIndex(
                name: "IX_HotelImage_Img_HotelIDhotel_id",
                table: "HotelImage",
                newName: "IX_HotelImage_img_hotel_id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelImage_Hotels_img_hotel_id",
                table: "HotelImage",
                column: "img_hotel_id",
                principalTable: "Hotels",
                principalColumn: "hotel_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelImage_Images_hotel_image_id",
                table: "HotelImage",
                column: "hotel_image_id",
                principalTable: "Images",
                principalColumn: "image_id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelImage_Hotels_img_hotel_id",
                table: "HotelImage");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelImage_Images_hotel_image_id",
                table: "HotelImage");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Hotels_rooms_hotel_id",
                table: "HotelRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Rooms_hotelR_room_id",
                table: "HotelRoom");

            migrationBuilder.RenameColumn(
                name: "rooms_hotel_id",
                table: "HotelRoom",
                newName: "RoomsHotelIDhotel_id");

            migrationBuilder.RenameColumn(
                name: "hotelR_room_id",
                table: "HotelRoom",
                newName: "HotelRoomIDroom_id");

            migrationBuilder.RenameIndex(
                name: "IX_HotelRoom_rooms_hotel_id",
                table: "HotelRoom",
                newName: "IX_HotelRoom_RoomsHotelIDhotel_id");

            migrationBuilder.RenameColumn(
                name: "img_hotel_id",
                table: "HotelImage",
                newName: "Img_HotelIDhotel_id");

            migrationBuilder.RenameColumn(
                name: "hotel_image_id",
                table: "HotelImage",
                newName: "Hotel_ImgIDimage_id");

            migrationBuilder.RenameIndex(
                name: "IX_HotelImage_img_hotel_id",
                table: "HotelImage",
                newName: "IX_HotelImage_Img_HotelIDhotel_id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelImage_Hotels_Img_HotelIDhotel_id",
                table: "HotelImage",
                column: "Img_HotelIDhotel_id",
                principalTable: "Hotels",
                principalColumn: "hotel_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelImage_Images_Hotel_ImgIDimage_id",
                table: "HotelImage",
                column: "Hotel_ImgIDimage_id",
                principalTable: "Images",
                principalColumn: "image_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Hotels_RoomsHotelIDhotel_id",
                table: "HotelRoom",
                column: "RoomsHotelIDhotel_id",
                principalTable: "Hotels",
                principalColumn: "hotel_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Rooms_HotelRoomIDroom_id",
                table: "HotelRoom",
                column: "HotelRoomIDroom_id",
                principalTable: "Rooms",
                principalColumn: "room_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
