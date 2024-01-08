using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CommentModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02826bcd-2b15-4c0a-8d85-281ade12b9b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59de2413-2986-49fa-a7ea-d2ee9bae8830");

            migrationBuilder.CreateTable(
                name: "AccountComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "longtext", nullable: true),
                    PlayerId = table.Column<string>(type: "longtext", nullable: true),
                    RecipientId = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountComments", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MatchComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "longtext", nullable: true),
                    PlayerId = table.Column<string>(type: "longtext", nullable: true),
                    MatchId = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchComments", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "92cc3801-f7f6-4e1b-85f0-ee1f50cae163", null, "Admin", "ADMIN" },
                    { "e3696a10-521c-49bb-bf50-a94046cedf2b", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountComments");

            migrationBuilder.DropTable(
                name: "MatchComments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92cc3801-f7f6-4e1b-85f0-ee1f50cae163");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3696a10-521c-49bb-bf50-a94046cedf2b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02826bcd-2b15-4c0a-8d85-281ade12b9b9", null, "Admin", "ADMIN" },
                    { "59de2413-2986-49fa-a7ea-d2ee9bae8830", null, "User", "USER" }
                });
        }
    }
}
