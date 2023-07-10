using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resify.Services.TablesAPI.Migrations
{
    public partial class InitialAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChairCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Category", "ChairCount", "RestaurantId" },
                values: new object[,]
                {
                    { new Guid("07a3695e-142d-464a-9159-8b0d527bcf2b"), "Pod oknem", 2, new Guid("945969d0-3883-466b-b632-c20fdf8a19bc") },
                    { new Guid("1b0878b6-3f49-4c30-9d50-c0a4d7c2ad3a"), "Pod oknem", 2, new Guid("5141148d-2d80-4c88-ace3-606ec8583143") },
                    { new Guid("83f23167-4ba7-42d0-9824-f67d87f692b7"), "W środku", 5, new Guid("945969d0-3883-466b-b632-c20fdf8a19bc") },
                    { new Guid("a3577c63-d6ea-44e1-9663-d2d63a982dfa"), "Pod oknem", 3, new Guid("945969d0-3883-466b-b632-c20fdf8a19bc") },
                    { new Guid("bf2d1c10-90a1-48c7-8645-9d8a2d35ea07"), "W środku", 5, new Guid("5141148d-2d80-4c88-ace3-606ec8583143") },
                    { new Guid("ea9b405b-7de6-4580-88e7-b340525f6871"), "Pod oknem", 3, new Guid("5141148d-2d80-4c88-ace3-606ec8583143") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
