using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEInvoice.Migrations
{
    public partial class updatestockWithVarient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VarientId",
                table: "Stocks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_VarientId",
                table: "Stocks",
                column: "VarientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Varients_VarientId",
                table: "Stocks",
                column: "VarientId",
                principalTable: "Varients",
                principalColumn: "VarientId"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
