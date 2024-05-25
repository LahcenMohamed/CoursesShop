using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class enccode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "AspNetUsers");
        }
    }
}
