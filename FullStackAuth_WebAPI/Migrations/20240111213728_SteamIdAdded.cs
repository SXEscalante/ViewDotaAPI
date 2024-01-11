using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SteamIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "711e2042-b3b8-4761-a101-330c26087bad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4991cc9-de8d-4446-b706-c2cda8cdc403");

            migrationBuilder.AddColumn<string>(
                name: "SteamId",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1892a1e2-57ef-4e61-896a-0b56edea01f4", null, "Admin", "ADMIN" },
                    { "4fe0e6fa-8ba5-4f1e-97f9-8b6c881855a1", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1892a1e2-57ef-4e61-896a-0b56edea01f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fe0e6fa-8ba5-4f1e-97f9-8b6c881855a1");

            migrationBuilder.DropColumn(
                name: "SteamId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "711e2042-b3b8-4761-a101-330c26087bad", null, "User", "USER" },
                    { "b4991cc9-de8d-4446-b706-c2cda8cdc403", null, "Admin", "ADMIN" }
                });
        }
    }
}
