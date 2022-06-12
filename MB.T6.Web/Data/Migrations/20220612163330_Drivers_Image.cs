using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MB.T6.Web.Data.Migrations
{
    public partial class Drivers_Image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Drivers");
        }
    }
}
