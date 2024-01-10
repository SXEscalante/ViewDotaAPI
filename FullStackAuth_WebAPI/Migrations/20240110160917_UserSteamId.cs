using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserSteamId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4079c559-c6e5-49e5-b49f-c6a7a7441ff7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59467701-b056-4fd5-88a6-cb38778aa35f");

            migrationBuilder.AddColumn<string>(
                name: "SteamAccountId",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "711e2042-b3b8-4761-a101-330c26087bad", null, "User", "USER" },
                    { "b4991cc9-de8d-4446-b706-c2cda8cdc403", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "711e2042-b3b8-4761-a101-330c26087bad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4991cc9-de8d-4446-b706-c2cda8cdc403");

            migrationBuilder.DropColumn(
                name: "SteamAccountId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4079c559-c6e5-49e5-b49f-c6a7a7441ff7", null, "Admin", "ADMIN" },
                    { "59467701-b056-4fd5-88a6-cb38778aa35f", null, "User", "USER" }
                });
        }
    }
}
