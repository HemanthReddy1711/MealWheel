using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealWheel.Migrations.MealDb
{
    public partial class addfav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "fav",
                table: "Food_Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fav",
                table: "Food_Products");
        }
    }
}
