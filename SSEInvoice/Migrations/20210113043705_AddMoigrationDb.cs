using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEInvoice.Migrations
{
    public partial class AddMoigrationDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Stocks_StocksId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_StocksId",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "StocksId",
                table: "Product",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Stocks_StocksId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_StocksId",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "StocksId",
                table: "Product",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_StocksId",
                table: "Product",
                column: "StocksId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Stocks_StocksId",
                table: "Product",
                column: "StocksId",
                principalTable: "Stocks",
                principalColumn: "StocksId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
