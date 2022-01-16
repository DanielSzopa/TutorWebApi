using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorWebApi.Migrations
{
    public partial class AddAudiTableEntityForTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Subjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Subjects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Subjects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Profiles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Likes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Likes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Likes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Likes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "Likes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Experiences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Experiences",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Experiences",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Adverts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Adverts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Adverts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "AdvertContacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "AdvertContacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AdvertContacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "AdvertContacts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "AdvertContacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Addresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Addresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Addresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Achievements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateId",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Achievements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Achievements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyId",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "CreateId", "IsActive" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1175), "", true });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "CreateId", "IsActive" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1214), "", true });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "CreateId", "IsActive" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1216), "", true });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "CreateId", "IsActive" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1218), "", true });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "CreateId", "IsActive" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1219), "", true });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreateDate", "CreateId", "IsActive" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1223), "", true });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreateDate", "CreateId", "IsActive" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1225), "", true });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreateDate", "CreateId", "IsActive" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1227), "", true });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreateDate", "CreateId", "IsActive" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1229), "", true });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreateDate", "CreateId", "IsActive" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1231), "", true });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreateDate", "CreateId", "IsActive" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1233), "", true });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreateDate", "CreateId", "IsActive" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1235), "", true });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreateDate", "CreateId", "IsActive" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1236), "", true });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreateDate", "CreateId", "IsActive" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1238), "", true });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreateDate", "CreateId", "IsActive" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1240), "", true });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreateDate", "CreateId", "IsActive" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1241), "", true });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreateDate", "CreateId", "IsActive" },
                values: new object[] { new DateTime(2022, 1, 16, 19, 44, 29, 978, DateTimeKind.Local).AddTicks(1243), "", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "AdvertContacts");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "AdvertContacts");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "AdvertContacts");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "AdvertContacts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AdvertContacts");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "AdvertContacts");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "AdvertContacts");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "CreateId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "InactivateDate",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "InactivateId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "ModifyId",
                table: "Achievements");
        }
    }
}
