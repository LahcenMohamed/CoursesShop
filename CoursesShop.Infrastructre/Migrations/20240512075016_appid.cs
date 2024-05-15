using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class appid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRefreshTokens_AspNetUsers_ApplicationUserId1",
                table: "UserRefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_UserRefreshTokens_ApplicationUserId1",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "UserRefreshTokens");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserRefreshTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "28e43834-14b6-4f39-81b9-96c1f883bb6c",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "5cefb1c9-6dd0-4149-9597-1660d1cb35c2");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "5955f957-dd5a-48c3-859c-4ff9bb08c67c",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "6f48a2d6-faab-4cba-8406-eaebc6366e73");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "064db656-6559-4d17-854e-6a153549494f",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "53ba569b-43a0-4372-b61e-b8a284937017");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "31a87779-9228-4a25-8739-3d141bf259ba",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "35fa7070-9eab-4424-80e1-93754aae9322");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "a670e481-6d08-4a34-bb89-41a85322f419",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "52369228-02cd-4bec-b422-4837f10f7a33");

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_ApplicationUserId",
                table: "UserRefreshTokens",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRefreshTokens_AspNetUsers_ApplicationUserId",
                table: "UserRefreshTokens",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRefreshTokens_AspNetUsers_ApplicationUserId",
                table: "UserRefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_UserRefreshTokens_ApplicationUserId",
                table: "UserRefreshTokens");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "UserRefreshTokens",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "UserRefreshTokens",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "5cefb1c9-6dd0-4149-9597-1660d1cb35c2",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "28e43834-14b6-4f39-81b9-96c1f883bb6c");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "6f48a2d6-faab-4cba-8406-eaebc6366e73",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "5955f957-dd5a-48c3-859c-4ff9bb08c67c");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "53ba569b-43a0-4372-b61e-b8a284937017",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "064db656-6559-4d17-854e-6a153549494f");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "35fa7070-9eab-4424-80e1-93754aae9322",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "31a87779-9228-4a25-8739-3d141bf259ba");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "52369228-02cd-4bec-b422-4837f10f7a33",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "a670e481-6d08-4a34-bb89-41a85322f419");

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_ApplicationUserId1",
                table: "UserRefreshTokens",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRefreshTokens_AspNetUsers_ApplicationUserId1",
                table: "UserRefreshTokens",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
