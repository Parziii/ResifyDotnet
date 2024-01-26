using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resify.Services.RestaurantsAPI.Migrations
{
    public partial class AddFavoriteAnd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FavoriteRestaurantId",
                table: "Restaurants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FavoriteRestaurants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteRestaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("5141148d-2d80-4c88-ace3-606ec8583143"),
                column: "Name",
                value: "Włoska restauracja");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("945969d0-3883-466b-b632-c20fdf8a19bc"),
                column: "Name",
                value: "Amerykańska restauracja");

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name", "RestaurantId" },
                values: new object[,]
                {
                    { new Guid("94596123-3883-466b-b632-c20fdf8a19bc"), "Italian", new Guid("5141148d-2d80-4c88-ace3-606ec8583143") },
                    { new Guid("94596124-3883-466b-b632-c20fdf8a19bc"), "American", new Guid("945969d0-3883-466b-b632-c20fdf8a19bc") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_FavoriteRestaurantId",
                table: "Restaurants",
                column: "FavoriteRestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_RestaurantId",
                table: "Tags",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_FavoriteRestaurants_FavoriteRestaurantId",
                table: "Restaurants",
                column: "FavoriteRestaurantId",
                principalTable: "FavoriteRestaurants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_FavoriteRestaurants_FavoriteRestaurantId",
                table: "Restaurants");

            migrationBuilder.DropTable(
                name: "FavoriteRestaurants");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_FavoriteRestaurantId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "FavoriteRestaurantId",
                table: "Restaurants");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("5141148d-2d80-4c88-ace3-606ec8583143"),
                column: "Name",
                value: "Restauracja1");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: new Guid("945969d0-3883-466b-b632-c20fdf8a19bc"),
                column: "Name",
                value: "Restauracja2");
        }
    }
}
