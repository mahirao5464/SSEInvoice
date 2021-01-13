using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEInvoice.Migrations
{
    public partial class AddUnitToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Stocks_StocksId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_StocksId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "StocksId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Stocks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateOn",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "Varients",
                columns: table => new
                {
                    VarientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VarientName = table.Column<string>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Varients", x => x.VarientId);
                    table.ForeignKey(
                        name: "FK_Varients_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Varients_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Varients_ProductId",
                table: "Varients",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Varients_UnitId",
                table: "Varients",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Product_ProductId",
                table: "Stocks",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Product_ProductId",
                table: "Stocks");

            migrationBuilder.DropTable(
                name: "Varients");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UpdateOn",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "StocksId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_StocksId",
                table: "Product",
                column: "StocksId",
                unique: true,
                filter: "[StocksId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Stocks_StocksId",
                table: "Product",
                column: "StocksId",
                principalTable: "Stocks",
                principalColumn: "StocksId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
