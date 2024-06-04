using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhereToStay.data.migrations
{
    /// <inheritdoc />
    public partial class updatefields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Features_features_id",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Hotels_hotel_id",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotels_hotel_id",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Reservations_reservation_id",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_hotel_id",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_reservation_id",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Images_hotel_id",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_features_id",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "hotel_id",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "reservation_id",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "hotel_id",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "features_id",
                table: "Hotels");

            migrationBuilder.AddColumn<int>(
                name: "room_id",
                table: "Reservations",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeaturesID",
                table: "Hotels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "image_id",
                table: "Hotels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "room_id",
                table: "Hotels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "hotel_id",
                table: "Destinations",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_room_id",
                table: "Reservations",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_FeaturesID",
                table: "Hotels",
                column: "FeaturesID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_image_id",
                table: "Hotels",
                column: "image_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_room_id",
                table: "Hotels",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_hotel_id",
                table: "Destinations",
                column: "hotel_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Hotels_hotel_id",
                table: "Destinations",
                column: "hotel_id",
                principalTable: "Hotels",
                principalColumn: "hotel_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Features_FeaturesID",
                table: "Hotels",
                column: "FeaturesID",
                principalTable: "Features",
                principalColumn: "features_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Images_image_id",
                table: "Hotels",
                column: "image_id",
                principalTable: "Images",
                principalColumn: "image_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Rooms_room_id",
                table: "Hotels",
                column: "room_id",
                principalTable: "Rooms",
                principalColumn: "room_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_room_id",
                table: "Reservations",
                column: "room_id",
                principalTable: "Rooms",
                principalColumn: "room_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Hotels_hotel_id",
                table: "Destinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Features_FeaturesID",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Images_image_id",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Rooms_room_id",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_room_id",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_room_id",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_FeaturesID",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_image_id",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_room_id",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_hotel_id",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "room_id",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "FeaturesID",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "image_id",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "room_id",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "hotel_id",
                table: "Destinations");

            migrationBuilder.AddColumn<int>(
                name: "hotel_id",
                table: "Rooms",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "reservation_id",
                table: "Rooms",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "hotel_id",
                table: "Images",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "features_id",
                table: "Hotels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_hotel_id",
                table: "Rooms",
                column: "hotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_reservation_id",
                table: "Rooms",
                column: "reservation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Images_hotel_id",
                table: "Images",
                column: "hotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_features_id",
                table: "Hotels",
                column: "features_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Features_features_id",
                table: "Hotels",
                column: "features_id",
                principalTable: "Features",
                principalColumn: "features_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Hotels_hotel_id",
                table: "Images",
                column: "hotel_id",
                principalTable: "Hotels",
                principalColumn: "hotel_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotels_hotel_id",
                table: "Rooms",
                column: "hotel_id",
                principalTable: "Hotels",
                principalColumn: "hotel_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Reservations_reservation_id",
                table: "Rooms",
                column: "reservation_id",
                principalTable: "Reservations",
                principalColumn: "reservation_id");
        }
    }
}
