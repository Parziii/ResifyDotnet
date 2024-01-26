using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resify.Services.RestaurantsAPI.Migrations
{
    public partial class RemoveStreetNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "Restaurants");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("5141148d-2d80-4c88-ace3-606ec8583143"),
                column: "Street",
                value: "Jagielońska 24");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("945969d0-3883-466b-b632-c20fdf8a19bc"),
                column: "Street",
                value: "Jagielońska 13");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StreetNumber",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("5141148d-2d80-4c88-ace3-606ec8583143"),
                columns: new[] { "Street", "StreetNumber" },
                values: new object[] { "Jagielońska", "30" });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("945969d0-3883-466b-b632-c20fdf8a19bc"),
                columns: new[] { "Street", "StreetNumber" },
                values: new object[] { "Jagielońska", "31" });
        }
    }
}
