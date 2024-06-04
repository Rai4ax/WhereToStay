using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhereToStay.data.migrations
{
    /// <inheritdoc />
    public partial class updatefields4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Img_Hotels_hotel_id",
                table: "Hotel_Img");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Img_Images_image_id",
                table: "Hotel_Img");

            migrationBuilder.AlterColumn<int>(
                name: "image_id",
                table: "Hotel_Img",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "hotel_id",
                table: "Hotel_Img",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Img_Hotels_hotel_id",
                table: "Hotel_Img",
                column: "hotel_id",
                principalTable: "Hotels",
                principalColumn: "hotel_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Img_Images_image_id",
                table: "Hotel_Img",
                column: "image_id",
                principalTable: "Images",
                principalColumn: "image_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Img_Hotels_hotel_id",
                table: "Hotel_Img");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Img_Images_image_id",
                table: "Hotel_Img");

            migrationBuilder.AlterColumn<int>(
                name: "image_id",
                table: "Hotel_Img",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "hotel_id",
                table: "Hotel_Img",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Img_Hotels_hotel_id",
                table: "Hotel_Img",
                column: "hotel_id",
                principalTable: "Hotels",
                principalColumn: "hotel_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Img_Images_image_id",
                table: "Hotel_Img",
                column: "image_id",
                principalTable: "Images",
                principalColumn: "image_id");
        }
    }
}
