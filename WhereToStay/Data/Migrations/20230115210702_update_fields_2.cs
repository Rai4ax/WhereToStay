using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WhereToStay.data.migrations
{
    /// <inheritdoc />
    public partial class updatefields2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Rooms_room_id",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_room_id",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "room_id",
                table: "Hotels");

            migrationBuilder.CreateTable(
                name: "HotelRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    hotelid = table.Column<int>(name: "hotel_id", type: "integer", nullable: true),
                    roomid = table.Column<int>(name: "room_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelRooms_Hotels_hotel_id",
                        column: x => x.hotelid,
                        principalTable: "Hotels",
                        principalColumn: "hotel_id");
                    table.ForeignKey(
                        name: "FK_HotelRooms_Rooms_room_id",
                        column: x => x.roomid,
                        principalTable: "Rooms",
                        principalColumn: "room_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_hotel_id",
                table: "HotelRooms",
                column: "hotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_room_id",
                table: "HotelRooms",
                column: "room_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelRooms");

            migrationBuilder.AddColumn<int>(
                name: "room_id",
                table: "Hotels",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_room_id",
                table: "Hotels",
                column: "room_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Rooms_room_id",
                table: "Hotels",
                column: "room_id",
                principalTable: "Rooms",
                principalColumn: "room_id");
        }
    }
}
