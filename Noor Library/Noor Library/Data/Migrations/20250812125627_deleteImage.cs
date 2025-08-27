using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Noor_Library.Data.Migrations
{
    /// <inheritdoc />
    public partial class deleteImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Security",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                schema: "Security",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
