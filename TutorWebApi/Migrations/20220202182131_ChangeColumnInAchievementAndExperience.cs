using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorWebApi.Migrations
{
    public partial class ChangeColumnInAchievementAndExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Experiences",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Achievements",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Experiences",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Achievements",
                newName: "Name");
        }
    }
}
