using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resify.Services.ReservationAPI.Migrations
{
    public partial class RemadeReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ReservationDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationHeaders",
                table: "ReservationHeaders");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "ReservationHeaders");

            migrationBuilder.DropColumn(
                name: "StarTime",
                table: "ReservationHeaders");

            migrationBuilder.RenameColumn(
                name: "ReservationHeaderId",
                table: "ReservationHeaders",
                newName: "RestaurantId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ReservationHeaders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ReservationHeaders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "ReservationHeaders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PeopleCount",
                table: "ReservationHeaders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "ReservationHeaders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                table: "ReservationHeaders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationHeaders",
                table: "ReservationHeaders",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationHeaders",
                table: "ReservationHeaders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReservationHeaders");

            migrationBuilder.DropColumn(
                name: "From",
                table: "ReservationHeaders");

            migrationBuilder.DropColumn(
                name: "PeopleCount",
                table: "ReservationHeaders");

            migrationBuilder.DropColumn(
                name: "State",
                table: "ReservationHeaders");

            migrationBuilder.DropColumn(
                name: "To",
                table: "ReservationHeaders");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "ReservationHeaders",
                newName: "ReservationHeaderId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ReservationHeaders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "ReservationHeaders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StarTime",
                table: "ReservationHeaders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationHeaders",
                table: "ReservationHeaders",
                column: "ReservationHeaderId");

            migrationBuilder.CreateTable(
                name: "ReservationDetails",
                columns: table => new
                {
                    ReservationDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationDetails", x => x.ReservationDetailId);
                    table.ForeignKey(
                        name: "FK_ReservationDetails_ReservationHeaders_ReservationHeaderId",
                        column: x => x.ReservationHeaderId,
                        principalTable: "ReservationHeaders",
                        principalColumn: "ReservationHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailsId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_ReservationDetails_ReservationDetailsId",
                        column: x => x.ReservationDetailsId,
                        principalTable: "ReservationDetails",
                        principalColumn: "ReservationDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ReservationDetailsId",
                table: "OrderDetails",
                column: "ReservationDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDetails_ReservationHeaderId",
                table: "ReservationDetails",
                column: "ReservationHeaderId");
        }
    }
}
