using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resify.Services.RestaurantsAPI.Migrations
{
    public partial class ModifyFavorite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_FavoriteRestaurants_FavoriteRestaurantId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_FavoriteRestaurantId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "FavoriteRestaurantId",
                table: "Restaurants");

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "FavoriteRestaurants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteRestaurants_RestaurantId",
                table: "FavoriteRestaurants",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteRestaurants_Restaurants_RestaurantId",
                table: "FavoriteRestaurants",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteRestaurants_Restaurants_RestaurantId",
                table: "FavoriteRestaurants");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteRestaurants_RestaurantId",
                table: "FavoriteRestaurants");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "FavoriteRestaurants");

            migrationBuilder.AddColumn<Guid>(
                name: "FavoriteRestaurantId",
                table: "Restaurants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_FavoriteRestaurantId",
                table: "Restaurants",
                column: "FavoriteRestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_FavoriteRestaurants_FavoriteRestaurantId",
                table: "Restaurants",
                column: "FavoriteRestaurantId",
                principalTable: "FavoriteRestaurants",
                principalColumn: "Id");
        }
    }
}
