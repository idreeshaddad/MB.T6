using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MB.T6.Web.Data.Migrations
{
    public partial class Drivers_Rating_PhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Drivers");
        }
    }
}
