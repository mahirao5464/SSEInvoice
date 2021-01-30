using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEInvoice.Migrations
{
    public partial class addcustvar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomVarient_Quotations_QuotationId",
                table: "CustomVarient");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomVarient_Varients_VarientId",
                table: "CustomVarient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomVarient",
                table: "CustomVarient");

            migrationBuilder.RenameTable(
                name: "CustomVarient",
                newName: "CustomVarients");

            migrationBuilder.RenameIndex(
                name: "IX_CustomVarient_VarientId",
                table: "CustomVarients",
                newName: "IX_CustomVarients_VarientId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomVarient_QuotationId",
                table: "CustomVarients",
                newName: "IX_CustomVarients_QuotationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomVarients",
                table: "CustomVarients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomVarients_Quotations_QuotationId",
                table: "CustomVarients",
                column: "QuotationId",
                principalTable: "Quotations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomVarients_Varients_VarientId",
                table: "CustomVarients",
                column: "VarientId",
                principalTable: "Varients",
                principalColumn: "VarientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomVarients_Quotations_QuotationId",
                table: "CustomVarients");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomVarients_Varients_VarientId",
                table: "CustomVarients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomVarients",
                table: "CustomVarients");

            migrationBuilder.RenameTable(
                name: "CustomVarients",
                newName: "CustomVarient");

            migrationBuilder.RenameIndex(
                name: "IX_CustomVarients_VarientId",
                table: "CustomVarient",
                newName: "IX_CustomVarient_VarientId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomVarients_QuotationId",
                table: "CustomVarient",
                newName: "IX_CustomVarient_QuotationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomVarient",
                table: "CustomVarient",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomVarient_Quotations_QuotationId",
                table: "CustomVarient",
                column: "QuotationId",
                principalTable: "Quotations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomVarient_Varients_VarientId",
                table: "CustomVarient",
                column: "VarientId",
                principalTable: "Varients",
                principalColumn: "VarientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
