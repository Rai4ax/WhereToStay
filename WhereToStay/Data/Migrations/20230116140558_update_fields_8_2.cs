using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhereToStay.data.migrations
{
    /// <inheritdoc />
    public partial class updatefields82 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HotelRoom",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HotelImage",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "HotelRoom");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HotelImage");
        }
    }
}
