using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Migrations
{
    /// <inheritdoc />
    public partial class createmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InventoryDetail_DetailID",
                table: "InventoryDetail");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Detail",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "InventoryAddEditViewModel",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryAddEditViewModel");

            migrationBuilder.DropTable(
                name: "InventoryListViewModel");

            migrationBuilder.DropIndex(
                name: "IX_InventoryDetail_DetailID",
                table: "InventoryDetail");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Detail",
                keyColumn: "DetailId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 2, 14, 7, 10, 505, DateTimeKind.Local).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "Detail",
                keyColumn: "DetailId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 2, 14, 7, 10, 505, DateTimeKind.Local).AddTicks(2214));

            migrationBuilder.UpdateData(
                table: "Detail",
                keyColumn: "DetailId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 2, 14, 7, 10, 505, DateTimeKind.Local).AddTicks(2215));

            migrationBuilder.UpdateData(
                table: "Detail",
                keyColumn: "DetailId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 2, 14, 7, 10, 505, DateTimeKind.Local).AddTicks(2216));

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDetail_DetailID",
                table: "InventoryDetail",
                column: "DetailID");
        }
    }
}
