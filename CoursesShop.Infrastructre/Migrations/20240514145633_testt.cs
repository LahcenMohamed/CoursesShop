using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class testt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserRefreshTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "7778d841-bd85-44b3-b00c-f08298614a41");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "1eecd3ae-3d6f-483d-95cb-207ae695552c");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "92fbf037-3cae-436a-b822-3a452f620599");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "6ba84a04-7930-443f-abd2-420e976f8c78");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "1b4a0630-9ec4-48da-8bb8-00ca2d654d09");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "7dcb49cf-e1dd-45d7-83a0-07e6057a057f");

            migrationBuilder.AlterColumn<string>(
                name: "TypeId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserRefreshTokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "7778d841-bd85-44b3-b00c-f08298614a41",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "0dc5c755-043f-4def-86ca-c8a1471ee93f");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "1eecd3ae-3d6f-483d-95cb-207ae695552c",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "2f0f35de-ea88-46d3-a363-7a2f16d3e264");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "92fbf037-3cae-436a-b822-3a452f620599",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "0290c24f-e7a9-4164-9fd9-6c5bc1a65795");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "6ba84a04-7930-443f-abd2-420e976f8c78",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "984f30c2-3c93-4185-a383-1971ef4d7c9a");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "1b4a0630-9ec4-48da-8bb8-00ca2d654d09",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "d4966127-cdb5-4be8-a0c1-217fa4762db0");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "7dcb49cf-e1dd-45d7-83a0-07e6057a057f",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "a995ec1f-2015-42bc-a255-3ce061a1fc14");

            migrationBuilder.AlterColumn<string>(
                name: "TypeId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
