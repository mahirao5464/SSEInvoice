using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEInvoice.Migrations
{
    public partial class addquot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomVarient_Quotations_QuotationId",
                table: "CustomVarient");

            migrationBuilder.AlterColumn<int>(
                name: "QuotationId",
                table: "CustomVarient",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomVarient_Quotations_QuotationId",
                table: "CustomVarient",
                column: "QuotationId",
                principalTable: "Quotations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomVarient_Quotations_QuotationId",
                table: "CustomVarient");

            migrationBuilder.AlterColumn<int>(
                name: "QuotationId",
                table: "CustomVarient",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CustomVarient_Quotations_QuotationId",
                table: "CustomVarient",
                column: "QuotationId",
                principalTable: "Quotations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
