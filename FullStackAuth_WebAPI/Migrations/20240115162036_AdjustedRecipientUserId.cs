using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdjustedRecipientUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountComments_AspNetUsers_RecipientUserId",
                table: "AccountComments");

            migrationBuilder.DropIndex(
                name: "IX_AccountComments_RecipientUserId",
                table: "AccountComments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1892a1e2-57ef-4e61-896a-0b56edea01f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fe0e6fa-8ba5-4f1e-97f9-8b6c881855a1");

            migrationBuilder.AlterColumn<string>(
                name: "RecipientUserId",
                table: "AccountComments",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a033858e-6186-4f8a-b621-c0dc1a37b010", null, "User", "USER" },
                    { "f2c240b8-fb97-4705-9e98-e38a5694c2bf", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a033858e-6186-4f8a-b621-c0dc1a37b010");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2c240b8-fb97-4705-9e98-e38a5694c2bf");

            migrationBuilder.AlterColumn<string>(
                name: "RecipientUserId",
                table: "AccountComments",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1892a1e2-57ef-4e61-896a-0b56edea01f4", null, "Admin", "ADMIN" },
                    { "4fe0e6fa-8ba5-4f1e-97f9-8b6c881855a1", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountComments_RecipientUserId",
                table: "AccountComments",
                column: "RecipientUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountComments_AspNetUsers_RecipientUserId",
                table: "AccountComments",
                column: "RecipientUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
