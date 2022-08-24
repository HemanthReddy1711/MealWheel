using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealWheel.Migrations.MealDb
{
    public partial class adding_uname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "myProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "myProfiles");
        }
    }
}
