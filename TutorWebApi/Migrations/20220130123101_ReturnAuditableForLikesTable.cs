using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorWebApi.Migrations
{
    public partial class ReturnAuditableForLikesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "Likes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Likes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Likes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ModifyById",
                table: "Likes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Likes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_UserId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Likes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                columns: new[] { "UserId", "ProfileId" });
        }
    }
}
