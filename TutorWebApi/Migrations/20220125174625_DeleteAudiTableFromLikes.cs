using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorWebApi.Migrations
{
    public partial class DeleteAudiTableFromLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "Id",
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

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 46, 25, 633, DateTimeKind.Local).AddTicks(6751));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 46, 25, 633, DateTimeKind.Local).AddTicks(6793));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 46, 25, 633, DateTimeKind.Local).AddTicks(6838));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 46, 25, 633, DateTimeKind.Local).AddTicks(6841));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 46, 25, 633, DateTimeKind.Local).AddTicks(6844));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 46, 25, 633, DateTimeKind.Local).AddTicks(6848));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 46, 25, 633, DateTimeKind.Local).AddTicks(6850));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 46, 25, 633, DateTimeKind.Local).AddTicks(6851));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 46, 25, 633, DateTimeKind.Local).AddTicks(6853));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 46, 25, 633, DateTimeKind.Local).AddTicks(6856));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 46, 25, 633, DateTimeKind.Local).AddTicks(6858));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 46, 25, 633, DateTimeKind.Local).AddTicks(6859));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 46, 25, 633, DateTimeKind.Local).AddTicks(6861));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 46, 25, 633, DateTimeKind.Local).AddTicks(6863));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 46, 25, 633, DateTimeKind.Local).AddTicks(6864));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 46, 25, 633, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 46, 25, 633, DateTimeKind.Local).AddTicks(6868));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 42, 11, 324, DateTimeKind.Local).AddTicks(7460));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 42, 11, 324, DateTimeKind.Local).AddTicks(7505));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 42, 11, 324, DateTimeKind.Local).AddTicks(7507));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 42, 11, 324, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 42, 11, 324, DateTimeKind.Local).AddTicks(7510));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 42, 11, 324, DateTimeKind.Local).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 42, 11, 324, DateTimeKind.Local).AddTicks(7517));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 42, 11, 324, DateTimeKind.Local).AddTicks(7519));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 42, 11, 324, DateTimeKind.Local).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 42, 11, 324, DateTimeKind.Local).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 42, 11, 324, DateTimeKind.Local).AddTicks(7526));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 42, 11, 324, DateTimeKind.Local).AddTicks(7528));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 42, 11, 324, DateTimeKind.Local).AddTicks(7571));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 42, 11, 324, DateTimeKind.Local).AddTicks(7573));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 42, 11, 324, DateTimeKind.Local).AddTicks(7575));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 42, 11, 324, DateTimeKind.Local).AddTicks(7577));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateDate",
                value: new DateTime(2022, 1, 25, 18, 42, 11, 324, DateTimeKind.Local).AddTicks(7578));
        }
    }
}
