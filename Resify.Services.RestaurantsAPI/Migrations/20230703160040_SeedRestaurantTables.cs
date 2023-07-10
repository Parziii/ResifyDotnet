using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resify.Services.RestaurantsAPI.Migrations
{
    public partial class SeedRestaurantTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "City", "Description", "Name", "Street", "StreetNumber", "ZipCode" },
                values: new object[] { new Guid("5141148d-2d80-4c88-ace3-606ec8583143"), "Kraków", "TestowyOpis", "Restauracja1", "Jagielońska", "30", "12-345" });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "City", "Description", "Name", "Street", "StreetNumber", "ZipCode" },
                values: new object[] { new Guid("945969d0-3883-466b-b632-c20fdf8a19bc"), "Kraków", "TestowyOpis2", "Restauracja2", "Jagielońska", "31", "12-345" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("5141148d-2d80-4c88-ace3-606ec8583143"));

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("945969d0-3883-466b-b632-c20fdf8a19bc"));
        }
    }
}
