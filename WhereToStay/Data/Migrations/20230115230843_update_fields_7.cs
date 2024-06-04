using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhereToStay.data.migrations
{
    /// <inheritdoc />
    public partial class updatefields7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelImage_Hotels_img_hotel_id",
                table: "HotelImage");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelImage_Images_hotel_image_id",
                table: "HotelImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "img_hotel_id",
                table: "HotelImage",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "hotel_image_id",
                table: "HotelImage",
                newName: "HotelId");

            migrationBuilder.RenameIndex(
                name: "IX_HotelImage_img_hotel_id",
                table: "HotelImage",
                newName: "IX_HotelImage_ImageId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reservations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelImage_Hotels_HotelId",
                table: "HotelImage",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "hotel_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelImage_Images_ImageId",
                table: "HotelImage",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "image_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelImage_Hotels_HotelId",
                table: "HotelImage");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelImage_Images_ImageId",
                table: "HotelImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "HotelImage",
                newName: "img_hotel_id");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "HotelImage",
                newName: "hotel_image_id");

            migrationBuilder.RenameIndex(
                name: "IX_HotelImage_ImageId",
                table: "HotelImage",
                newName: "IX_HotelImage_img_hotel_id");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reservations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
