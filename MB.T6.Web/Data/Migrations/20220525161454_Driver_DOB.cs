using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MB.T6.Web.Data.Migrations
{
    public partial class Driver_DOB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Drivers",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Drivers");
        }
    }
}
