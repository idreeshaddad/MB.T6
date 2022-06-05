using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MB.T6.Web.Data.Migrations
{
    public partial class Car_Props : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSeats",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductionDate",
                table: "Cars",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "NumberOfSeats",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "Cars");
        }
    }
}
