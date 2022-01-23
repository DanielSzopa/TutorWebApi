using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorWebApi.Migrations
{
    public partial class ChangePropertiesInAuditableEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "AdvertContacts");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "AdvertContacts");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "Achievements");

            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyById",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyById",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "Profiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyById",
                table: "Profiles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "Likes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyById",
                table: "Likes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "Experiences",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyById",
                table: "Experiences",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyById",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "Adverts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyById",
                table: "Adverts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "AdvertContacts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyById",
                table: "AdvertContacts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyById",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateById",
                table: "Achievements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifyById",
                table: "Achievements",
                type: "int",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "AdvertContacts");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "AdvertContacts");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "ModifyById",
                table: "Achievements");

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Likes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "Likes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "AdvertContacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "AdvertContacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "CreateId" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1175), "" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "CreateId" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1214), "" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "CreateId" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1216), "" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "CreateId" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1218), "" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "CreateId" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1219), "" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreateDate", "CreateId" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1223), "" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreateDate", "CreateId" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1225), "" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreateDate", "CreateId" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1227), "" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreateDate", "CreateId" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1229), "" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreateDate", "CreateId" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1231), "" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreateDate", "CreateId" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1233), "" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreateDate", "CreateId" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1235), "" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreateDate", "CreateId" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1236), "" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreateDate", "CreateId" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1238), "" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreateDate", "CreateId" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1240), "" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreateDate", "CreateId" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1241), "" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreateDate", "CreateId" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1243), "" });
        }
    }
}
