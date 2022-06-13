using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MB.T6.Web.Data.Migrations
{
    public partial class Car_PlateNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlateNumber",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlateNumber",
                table: "Cars");
        }
    }
}
