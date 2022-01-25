using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorWebApi.Migrations
{
    public partial class AudiTableChangeColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "AdvertContacts");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "AdvertContacts");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "Achievements");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InactivateDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InactivateId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InactivateDate",
                table: "Subjects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InactivateId",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InactivateDate",
                table: "Profiles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InactivateId",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InactivateDate",
                table: "Likes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InactivateId",
                table: "Likes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InactivateDate",
                table: "Experiences",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InactivateId",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InactivateDate",
                table: "Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InactivateId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InactivateDate",
                table: "Adverts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InactivateId",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InactivateDate",
                table: "AdvertContacts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InactivateId",
                table: "AdvertContacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InactivateDate",
                table: "Addresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InactivateId",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InactivateDate",
                table: "Achievements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InactivateId",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 1, 23, 14, 20, 23, 61, DateTimeKind.Local).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 1, 23, 14, 20, 23, 61, DateTimeKind.Local).AddTicks(356));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 1, 23, 14, 20, 23, 61, DateTimeKind.Local).AddTicks(358));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 1, 23, 14, 20, 23, 61, DateTimeKind.Local).AddTicks(359));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 1, 23, 14, 20, 23, 61, DateTimeKind.Local).AddTicks(361));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2022, 1, 23, 14, 20, 23, 61, DateTimeKind.Local).AddTicks(404));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2022, 1, 23, 14, 20, 23, 61, DateTimeKind.Local).AddTicks(406));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2022, 1, 23, 14, 20, 23, 61, DateTimeKind.Local).AddTicks(408));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateDate",
                value: new DateTime(2022, 1, 23, 14, 20, 23, 61, DateTimeKind.Local).AddTicks(410));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateDate",
                value: new DateTime(2022, 1, 23, 14, 20, 23, 61, DateTimeKind.Local).AddTicks(413));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateDate",
                value: new DateTime(2022, 1, 23, 14, 20, 23, 61, DateTimeKind.Local).AddTicks(415));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateDate",
                value: new DateTime(2022, 1, 23, 14, 20, 23, 61, DateTimeKind.Local).AddTicks(417));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateDate",
                value: new DateTime(2022, 1, 23, 14, 20, 23, 61, DateTimeKind.Local).AddTicks(418));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateDate",
                value: new DateTime(2022, 1, 23, 14, 20, 23, 61, DateTimeKind.Local).AddTicks(420));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateDate",
                value: new DateTime(2022, 1, 23, 14, 20, 23, 61, DateTimeKind.Local).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateDate",
                value: new DateTime(2022, 1, 23, 14, 20, 23, 61, DateTimeKind.Local).AddTicks(424));

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateDate",
                value: new DateTime(2022, 1, 23, 14, 20, 23, 61, DateTimeKind.Local).AddTicks(426));
        }
    }
}
