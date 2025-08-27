using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Noor_Library.Data.Migrations
{
    /// <inheritdoc />
    public partial class addnewcoloums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pdf",
                table: "books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "books");

            migrationBuilder.DropColumn(
                name: "Pdf",
                table: "books");
        }
    }
}
