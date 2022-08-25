using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealWheel.Migrations.MealDb
{
    public partial class adduname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "uname",
                table: "myOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "uname",
                table: "favorites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "uname",
                table: "carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "uname",
                table: "addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "uname",
                table: "myOrders");

            migrationBuilder.DropColumn(
                name: "uname",
                table: "favorites");

            migrationBuilder.DropColumn(
                name: "uname",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "uname",
                table: "addresses");
        }
    }
}
