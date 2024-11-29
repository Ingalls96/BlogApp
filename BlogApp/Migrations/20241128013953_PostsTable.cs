using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Migrations
{
    /// <inheritdoc />
    public partial class PostsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0af31cf6-3e76-44f5-89fe-dc84d59be948", "2552b380-a4da-4c85-b3bd-546dfc2efb44" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d22e433d-b1c2-4334-8c36-d14019c0c68b", "72908a83-c631-4408-b7c3-93fad4684ef4" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreateDate", "EditDate", "OwnerID", "PostText" },
                values: new object[] { 1, new DateTime(2024, 11, 26, 20, 48, 48, 126, DateTimeKind.Local).AddTicks(717), new DateTime(2024, 11, 26, 20, 48, 48, 126, DateTimeKind.Local).AddTicks(779), "1", "Test Post 1" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentText", "CreateDate", "EditDate", "OwnerID", "PostId" },
                values: new object[] { 1, "Comment 1", new DateTime(2024, 11, 26, 20, 48, 48, 126, DateTimeKind.Local).AddTicks(815), new DateTime(2024, 11, 26, 20, 48, 48, 126, DateTimeKind.Local).AddTicks(818), "1", 1 });
        }
    }
}
