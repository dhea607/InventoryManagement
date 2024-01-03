using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Migrations
{
    /// <inheritdoc />
    public partial class initialconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryAddEditViewModel");

            migrationBuilder.DropTable(
                name: "InventoryListViewModel");

            migrationBuilder.UpdateData(
                table: "Detail",
                keyColumn: "DetailId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 3, 9, 3, 52, 39, DateTimeKind.Local).AddTicks(9289));

            migrationBuilder.UpdateData(
                table: "Detail",
                keyColumn: "DetailId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 3, 9, 3, 52, 39, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "Detail",
                keyColumn: "DetailId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 3, 9, 3, 52, 39, DateTimeKind.Local).AddTicks(9301));

            migrationBuilder.UpdateData(
                table: "Detail",
                keyColumn: "DetailId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 3, 9, 3, 52, 39, DateTimeKind.Local).AddTicks(9302));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryAddEditViewModel",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "InventoryListViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryListViewModel", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Detail",
                keyColumn: "DetailId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 3, 8, 55, 25, 373, DateTimeKind.Local).AddTicks(2408));

            migrationBuilder.UpdateData(
                table: "Detail",
                keyColumn: "DetailId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 3, 8, 55, 25, 373, DateTimeKind.Local).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "Detail",
                keyColumn: "DetailId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 3, 8, 55, 25, 373, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "Detail",
                keyColumn: "DetailId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 3, 8, 55, 25, 373, DateTimeKind.Local).AddTicks(2419));
        }
    }
}
