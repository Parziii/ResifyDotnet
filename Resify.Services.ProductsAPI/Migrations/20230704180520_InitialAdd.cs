using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resify.Services.ProductsAPI.Migrations
{
    public partial class InitialAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2a61304d-3308-45c6-805a-42fa4a5dfaac"), "Polskie" },
                    { new Guid("2bcb40ca-9beb-4f18-a4d2-89395e9e3e4b"), "Amerykańskie" },
                    { new Guid("50b399c5-4b4f-4568-b3ce-2a339e445f36"), "Włoskie" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageUrl", "Name", "Price", "ProductCategoryId", "RestaurantId" },
                values: new object[,]
                {
                    { new Guid("277ff66d-fd38-4a8f-92aa-76632259308b"), "nic", "Pierogi", 30.50m, new Guid("2a61304d-3308-45c6-805a-42fa4a5dfaac"), new Guid("5141148d-2d80-4c88-ace3-606ec8583143") },
                    { new Guid("63fdf0b2-ffa0-4f4c-8a15-f826951826e1"), "nic", "Spaghetti", 23.50m, new Guid("50b399c5-4b4f-4568-b3ce-2a339e445f36"), new Guid("5141148d-2d80-4c88-ace3-606ec8583143") },
                    { new Guid("a3a1eb98-717c-4979-a3c3-7abdc0d3cc05"), "nic", "Hamburger", 38.50m, new Guid("2bcb40ca-9beb-4f18-a4d2-89395e9e3e4b"), new Guid("945969d0-3883-466b-b632-c20fdf8a19bc") },
                    { new Guid("a8729dee-321c-4798-a906-dec7167ec277"), "nic", "Pizza", 13.12m, new Guid("50b399c5-4b4f-4568-b3ce-2a339e445f36"), new Guid("5141148d-2d80-4c88-ace3-606ec8583143") },
                    { new Guid("d153b070-74a7-42ed-9c47-7bbae74d81c3"), "nic", "Frytki", 8.99m, new Guid("2bcb40ca-9beb-4f18-a4d2-89395e9e3e4b"), new Guid("945969d0-3883-466b-b632-c20fdf8a19bc") },
                    { new Guid("d262ed04-92e4-4f9a-bf20-cfc2a72f76e9"), "nic", "Pizza", 45m, new Guid("2bcb40ca-9beb-4f18-a4d2-89395e9e3e4b"), new Guid("945969d0-3883-466b-b632-c20fdf8a19bc") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
