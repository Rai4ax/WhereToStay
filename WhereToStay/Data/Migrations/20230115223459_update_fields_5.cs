using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WhereToStay.data.migrations
{
    /// <inheritdoc />
    public partial class updatefields5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotel_Img");

            migrationBuilder.DropTable(
                name: "HotelRooms");

            migrationBuilder.CreateTable(
                name: "HotelImage",
                columns: table => new
                {
                    HotelImgIDimageid = table.Column<int>(name: "Hotel_ImgIDimage_id", type: "integer", nullable: false),
                    ImgHotelIDhotelid = table.Column<int>(name: "Img_HotelIDhotel_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelImage", x => new { x.HotelImgIDimageid, x.ImgHotelIDhotelid });
                    table.ForeignKey(
                        name: "FK_HotelImage_Hotels_Img_HotelIDhotel_id",
                        column: x => x.ImgHotelIDhotelid,
                        principalTable: "Hotels",
                        principalColumn: "hotel_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelImage_Images_Hotel_ImgIDimage_id",
                        column: x => x.HotelImgIDimageid,
                        principalTable: "Images",
                        principalColumn: "image_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelRoom",
                columns: table => new
                {
                    HotelRoomIDroomid = table.Column<int>(name: "HotelRoomIDroom_id", type: "integer", nullable: false),
                    RoomsHotelIDhotelid = table.Column<int>(name: "RoomsHotelIDhotel_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoom", x => new { x.HotelRoomIDroomid, x.RoomsHotelIDhotelid });
                    table.ForeignKey(
                        name: "FK_HotelRoom_Hotels_RoomsHotelIDhotel_id",
                        column: x => x.RoomsHotelIDhotelid,
                        principalTable: "Hotels",
                        principalColumn: "hotel_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelRoom_Rooms_HotelRoomIDroom_id",
                        column: x => x.HotelRoomIDroomid,
                        principalTable: "Rooms",
                        principalColumn: "room_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelImage_Img_HotelIDhotel_id",
                table: "HotelImage",
                column: "Img_HotelIDhotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_RoomsHotelIDhotel_id",
                table: "HotelRoom",
                column: "RoomsHotelIDhotel_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelImage");

            migrationBuilder.DropTable(
                name: "HotelRoom");

            migrationBuilder.CreateTable(
                name: "Hotel_Img",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    hotelid = table.Column<int>(name: "hotel_id", type: "integer", nullable: false),
                    imageid = table.Column<int>(name: "image_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel_Img", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotel_Img_Hotels_hotel_id",
                        column: x => x.hotelid,
                        principalTable: "Hotels",
                        principalColumn: "hotel_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hotel_Img_Images_image_id",
                        column: x => x.imageid,
                        principalTable: "Images",
                        principalColumn: "image_id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Hotel_Img_hotel_id",
                table: "Hotel_Img",
                column: "hotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_Img_image_id",
                table: "Hotel_Img",
                column: "image_id");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_hotel_id",
                table: "HotelRooms",
                column: "hotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_room_id",
                table: "HotelRooms",
                column: "room_id");
        }
    }
}
