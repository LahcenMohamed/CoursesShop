using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class courseimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserRefreshTokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "290bb156-2509-4fba-a77d-eaf9c3a5b31f",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "4dff158a-d2a7-4c02-a815-85bd9aa01e9e");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "bd9c2285-863c-4251-a9e6-ce7f31e6d1af",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "2d4f094f-03d7-4ea1-9177-ad02d5bf1820");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "d509422b-e614-477f-9569-6d79116c4724",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "caf898eb-e1bd-4a41-a7bf-3abf59602c60");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "6f349303-f015-43c9-90f2-99f58d5c04f0",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "7b3bbefa-3fb5-403f-b9dd-6726a1cca7c6");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "21908eda-bfd2-4955-92bb-f3f3375a9ec5",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "137c5413-6cea-408e-8da4-067150b3e0d9");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "bca66c43-4e00-4926-9de4-1136648494aa",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "2690386d-3bd4-40d5-a122-8b29fb07fa5a");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "/Images/Courses/DefultCourse.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserRefreshTokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "4dff158a-d2a7-4c02-a815-85bd9aa01e9e",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "290bb156-2509-4fba-a77d-eaf9c3a5b31f");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "2d4f094f-03d7-4ea1-9177-ad02d5bf1820",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "bd9c2285-863c-4251-a9e6-ce7f31e6d1af");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "caf898eb-e1bd-4a41-a7bf-3abf59602c60",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "d509422b-e614-477f-9569-6d79116c4724");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "7b3bbefa-3fb5-403f-b9dd-6726a1cca7c6",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "6f349303-f015-43c9-90f2-99f58d5c04f0");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "137c5413-6cea-408e-8da4-067150b3e0d9",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "21908eda-bfd2-4955-92bb-f3f3375a9ec5");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "2690386d-3bd4-40d5-a122-8b29fb07fa5a",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "bca66c43-4e00-4926-9de4-1136648494aa");
        }
    }
}
