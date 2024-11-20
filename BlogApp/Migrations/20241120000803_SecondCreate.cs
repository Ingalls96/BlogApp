using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0b49bac2-14b2-4fa1-afe7-591a79292a2e", "e2c9e8e4-a5cb-4d32-846b-b927d2c9896a" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2d17ed95-bc3c-4293-aa5f-86b5644b527a", "f68c61e9-543b-4a05-b44b-4f922313efad" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "EditDate" },
                values: new object[] { new DateTime(2024, 11, 19, 19, 7, 24, 458, DateTimeKind.Local).AddTicks(7123), new DateTime(2024, 11, 19, 19, 7, 24, 458, DateTimeKind.Local).AddTicks(7124) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "EditDate" },
                values: new object[] { new DateTime(2024, 11, 19, 19, 7, 24, 458, DateTimeKind.Local).AddTicks(7076), new DateTime(2024, 11, 19, 19, 7, 24, 458, DateTimeKind.Local).AddTicks(7109) });
        }
    }
}
