using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CliverApi.Migrations
{
    public partial class InittialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Label",
                table: "Review",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "Review");
        }
    }
}
