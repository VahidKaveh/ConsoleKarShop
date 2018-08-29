using Microsoft.EntityFrameworkCore.Migrations;

namespace NikamoozShop.Infrastructures.EF.Migrations
{
    public partial class FixCourseTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTeacher_Teachers_TeacherId",
                table: "CourseTeacher");

            migrationBuilder.DropColumn(
                name: "TecherId",
                table: "CourseTeacher");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "CourseTeacher",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTeacher_Teachers_TeacherId",
                table: "CourseTeacher",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTeacher_Teachers_TeacherId",
                table: "CourseTeacher");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "CourseTeacher",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TecherId",
                table: "CourseTeacher",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTeacher_Teachers_TeacherId",
                table: "CourseTeacher",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
