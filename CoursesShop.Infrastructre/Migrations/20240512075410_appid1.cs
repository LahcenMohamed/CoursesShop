using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class appid1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserRefreshTokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "7778d841-bd85-44b3-b00c-f08298614a41",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "1eecd3ae-3d6f-483d-95cb-207ae695552c",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "28e43834-14b6-4f39-81b9-96c1f883bb6c");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "92fbf037-3cae-436a-b822-3a452f620599",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "5955f957-dd5a-48c3-859c-4ff9bb08c67c");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "6ba84a04-7930-443f-abd2-420e976f8c78",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "064db656-6559-4d17-854e-6a153549494f");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "1b4a0630-9ec4-48da-8bb8-00ca2d654d09",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "31a87779-9228-4a25-8739-3d141bf259ba");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "7dcb49cf-e1dd-45d7-83a0-07e6057a057f",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "a670e481-6d08-4a34-bb89-41a85322f419");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: "28e43834-14b6-4f39-81b9-96c1f883bb6c",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "1eecd3ae-3d6f-483d-95cb-207ae695552c");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "5955f957-dd5a-48c3-859c-4ff9bb08c67c",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "92fbf037-3cae-436a-b822-3a452f620599");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "064db656-6559-4d17-854e-6a153549494f",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "6ba84a04-7930-443f-abd2-420e976f8c78");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Receipts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "31a87779-9228-4a25-8739-3d141bf259ba",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "1b4a0630-9ec4-48da-8bb8-00ca2d654d09");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "a670e481-6d08-4a34-bb89-41a85322f419",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "7dcb49cf-e1dd-45d7-83a0-07e6057a057f");
        }
    }
}
