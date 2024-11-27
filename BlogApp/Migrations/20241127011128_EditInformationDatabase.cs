using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations
{
    /// <inheritdoc />
    public partial class EditInformationDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "100c60f2-f7ef-476c-8ac5-dd3c9312c507", "blah@blah.com", "555-555-5555", "bb5ccc8f-eef6-4fab-8d53-ef7ea5b6ee30" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "EditDate" },
                values: new object[] { new DateTime(2024, 11, 26, 20, 11, 28, 505, DateTimeKind.Local).AddTicks(8264), new DateTime(2024, 11, 26, 20, 11, 28, 505, DateTimeKind.Local).AddTicks(8490) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "EditDate" },
                values: new object[] { new DateTime(2024, 11, 26, 20, 11, 28, 505, DateTimeKind.Local).AddTicks(8170), new DateTime(2024, 11, 26, 20, 11, 28, 505, DateTimeKind.Local).AddTicks(8228) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "0b49bac2-14b2-4fa1-afe7-591a79292a2e", null, null, "e2c9e8e4-a5cb-4d32-846b-b927d2c9896a" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "EditDate" },
                values: new object[] { new DateTime(2024, 11, 19, 19, 8, 2, 986, DateTimeKind.Local).AddTicks(3982), new DateTime(2024, 11, 19, 19, 8, 2, 986, DateTimeKind.Local).AddTicks(3983) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "EditDate" },
                values: new object[] { new DateTime(2024, 11, 19, 19, 8, 2, 986, DateTimeKind.Local).AddTicks(3938), new DateTime(2024, 11, 19, 19, 8, 2, 986, DateTimeKind.Local).AddTicks(3969) });
        }
    }
}
