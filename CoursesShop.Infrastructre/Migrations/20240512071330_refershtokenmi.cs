using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refershtokenmi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "5cefb1c9-6dd0-4149-9597-1660d1cb35c2",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "6f48a2d6-faab-4cba-8406-eaebc6366e73",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "53ba569b-43a0-4372-b61e-b8a284937017",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "35fa7070-9eab-4424-80e1-93754aae9322",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "52369228-02cd-4bec-b422-4837f10f7a33",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "UserRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRefreshTokens_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_ApplicationUserId1",
                table: "UserRefreshTokens",
                column: "ApplicationUserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRefreshTokens");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "5cefb1c9-6dd0-4149-9597-1660d1cb35c2");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "6f48a2d6-faab-4cba-8406-eaebc6366e73");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "53ba569b-43a0-4372-b61e-b8a284937017");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "35fa7070-9eab-4424-80e1-93754aae9322");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "52369228-02cd-4bec-b422-4837f10f7a33");
        }
    }
}
