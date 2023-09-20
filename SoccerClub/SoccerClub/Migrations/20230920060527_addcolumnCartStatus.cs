using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerClub.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnCartStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CartStatus",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartStatus",
                table: "Carts");
        }
    }
}
