using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WhereToStay.data.migrations
{
    /// <inheritdoc />
    public partial class updatefields3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Images_image_id",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_image_id",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "image_id",
                table: "Hotels");

            migrationBuilder.CreateTable(
                name: "Hotel_Img",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    hotelid = table.Column<int>(name: "hotel_id", type: "integer", nullable: true),
                    imageid = table.Column<int>(name: "image_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel_Img", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotel_Img_Hotels_hotel_id",
                        column: x => x.hotelid,
                        principalTable: "Hotels",
                        principalColumn: "hotel_id");
                    table.ForeignKey(
                        name: "FK_Hotel_Img_Images_image_id",
                        column: x => x.imageid,
                        principalTable: "Images",
                        principalColumn: "image_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_Img_hotel_id",
                table: "Hotel_Img",
                column: "hotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_Img_image_id",
                table: "Hotel_Img",
                column: "image_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotel_Img");

            migrationBuilder.AddColumn<int>(
                name: "image_id",
                table: "Hotels",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_image_id",
                table: "Hotels",
                column: "image_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Images_image_id",
                table: "Hotels",
                column: "image_id",
                principalTable: "Images",
                principalColumn: "image_id");
        }
    }
}
