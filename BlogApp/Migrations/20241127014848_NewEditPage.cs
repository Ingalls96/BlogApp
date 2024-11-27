using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations
{
    /// <inheritdoc />
    public partial class NewEditPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "d22e433d-b1c2-4334-8c36-d14019c0c68b", "72908a83-c631-4408-b7c3-93fad4684ef4", "user" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "EditDate" },
                values: new object[] { new DateTime(2024, 11, 26, 20, 48, 48, 126, DateTimeKind.Local).AddTicks(815), new DateTime(2024, 11, 26, 20, 48, 48, 126, DateTimeKind.Local).AddTicks(818) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "EditDate" },
                values: new object[] { new DateTime(2024, 11, 26, 20, 48, 48, 126, DateTimeKind.Local).AddTicks(717), new DateTime(2024, 11, 26, 20, 48, 48, 126, DateTimeKind.Local).AddTicks(779) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp", "UserName" },
                values: new object[] { "100c60f2-f7ef-476c-8ac5-dd3c9312c507", "bb5ccc8f-eef6-4fab-8d53-ef7ea5b6ee30", null });

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
    }
}
