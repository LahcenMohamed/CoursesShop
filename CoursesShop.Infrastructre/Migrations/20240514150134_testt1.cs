using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class testt1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserRefreshTokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "31a9707f-4ed0-4591-ace6-904ec6162c32",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "0dc5c755-043f-4def-86ca-c8a1471ee93f");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "4dfa28b7-3977-4257-8f3b-f7d551f0268f",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "2f0f35de-ea88-46d3-a363-7a2f16d3e264");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "c22c08aa-dda0-481e-a435-167d1bb5abe5",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "0290c24f-e7a9-4164-9fd9-6c5bc1a65795");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "c8d959b2-0181-4962-891d-c00c2351dcef",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "984f30c2-3c93-4185-a383-1971ef4d7c9a");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "20eaaa35-825c-4265-b9bd-da4ed41bca5a",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "d4966127-cdb5-4be8-a0c1-217fa4762db0");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "45c68903-98b0-4f30-baac-0ded6ba1c619",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserRefreshTokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "0dc5c755-043f-4def-86ca-c8a1471ee93f",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "31a9707f-4ed0-4591-ace6-904ec6162c32");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "2f0f35de-ea88-46d3-a363-7a2f16d3e264",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "4dfa28b7-3977-4257-8f3b-f7d551f0268f");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "0290c24f-e7a9-4164-9fd9-6c5bc1a65795",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "c22c08aa-dda0-481e-a435-167d1bb5abe5");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "984f30c2-3c93-4185-a383-1971ef4d7c9a",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "c8d959b2-0181-4962-891d-c00c2351dcef");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "d4966127-cdb5-4be8-a0c1-217fa4762db0",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "20eaaa35-825c-4265-b9bd-da4ed41bca5a");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "a995ec1f-2015-42bc-a255-3ce061a1fc14",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "45c68903-98b0-4f30-baac-0ded6ba1c619");

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
    }
}
