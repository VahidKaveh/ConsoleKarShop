using Microsoft.EntityFrameworkCore.Migrations;

namespace NikamoozShop.Infrastructures.EF.Migrations
{
    public partial class AddIsDeletedToTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Teachers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Teachers");
        }
    }
}
