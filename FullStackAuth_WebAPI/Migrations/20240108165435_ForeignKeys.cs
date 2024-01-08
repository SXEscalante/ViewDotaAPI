using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92cc3801-f7f6-4e1b-85f0-ee1f50cae163");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3696a10-521c-49bb-bf50-a94046cedf2b");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "MatchComments");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "AccountComments");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "AccountComments");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MatchComments",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostingUserId",
                table: "AccountComments",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecipientUserId",
                table: "AccountComments",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4079c559-c6e5-49e5-b49f-c6a7a7441ff7", null, "Admin", "ADMIN" },
                    { "59467701-b056-4fd5-88a6-cb38778aa35f", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchComments_UserId",
                table: "MatchComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountComments_PostingUserId",
                table: "AccountComments",
                column: "PostingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountComments_RecipientUserId",
                table: "AccountComments",
                column: "RecipientUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountComments_AspNetUsers_PostingUserId",
                table: "AccountComments",
                column: "PostingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountComments_AspNetUsers_RecipientUserId",
                table: "AccountComments",
                column: "RecipientUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchComments_AspNetUsers_UserId",
                table: "MatchComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountComments_AspNetUsers_PostingUserId",
                table: "AccountComments");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountComments_AspNetUsers_RecipientUserId",
                table: "AccountComments");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchComments_AspNetUsers_UserId",
                table: "MatchComments");

            migrationBuilder.DropIndex(
                name: "IX_MatchComments_UserId",
                table: "MatchComments");

            migrationBuilder.DropIndex(
                name: "IX_AccountComments_PostingUserId",
                table: "AccountComments");

            migrationBuilder.DropIndex(
                name: "IX_AccountComments_RecipientUserId",
                table: "AccountComments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4079c559-c6e5-49e5-b49f-c6a7a7441ff7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59467701-b056-4fd5-88a6-cb38778aa35f");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MatchComments");

            migrationBuilder.DropColumn(
                name: "PostingUserId",
                table: "AccountComments");

            migrationBuilder.DropColumn(
                name: "RecipientUserId",
                table: "AccountComments");

            migrationBuilder.AddColumn<string>(
                name: "PlayerId",
                table: "MatchComments",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlayerId",
                table: "AccountComments",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecipientId",
                table: "AccountComments",
                type: "longtext",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "92cc3801-f7f6-4e1b-85f0-ee1f50cae163", null, "Admin", "ADMIN" },
                    { "e3696a10-521c-49bb-bf50-a94046cedf2b", null, "User", "USER" }
                });
        }
    }
}
