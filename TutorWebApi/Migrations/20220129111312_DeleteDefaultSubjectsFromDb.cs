using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorWebApi.Migrations
{
    public partial class DeleteDefaultSubjectsFromDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 17);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreateById", "CreateDate", "IsActive", "ModifyById", "ModifyDate", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9349), true, null, null, "Polish" },
                    { 2, null, new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9395), true, null, null, "English" },
                    { 3, null, new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9397), true, null, null, "French" },
                    { 4, null, new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9399), true, null, null, "German" },
                    { 5, null, new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9401), true, null, null, "Front-end Programming" },
                    { 6, null, new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9404), true, null, null, "Back-End Programming" },
                    { 7, null, new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9406), true, null, null, "Database" },
                    { 8, null, new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9408), true, null, null, "Maths" },
                    { 9, null, new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9410), true, null, null, "Physics" },
                    { 10, null, new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9412), true, null, null, "Chemistry" },
                    { 11, null, new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9414), true, null, null, "Geography" },
                    { 12, null, new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9416), true, null, null, "History" },
                    { 13, null, new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9417), true, null, null, "Science" },
                    { 14, null, new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9419), true, null, null, "Art" },
                    { 15, null, new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9421), true, null, null, "It" },
                    { 16, null, new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9423), true, null, null, "Technology" },
                    { 17, null, new DateTime(2022, 1, 26, 17, 53, 3, 355, DateTimeKind.Local).AddTicks(9424), true, null, null, "Business Studies" }
                });
        }
    }
}
