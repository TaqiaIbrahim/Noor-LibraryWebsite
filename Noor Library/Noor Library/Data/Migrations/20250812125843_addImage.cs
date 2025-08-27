using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Noor_Library.Data.Migrations
{
    /// <inheritdoc />
    public partial class addImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "profile",
                schema: "Security",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profile",
                schema: "Security",
                table: "Users");
        }
    }
}
