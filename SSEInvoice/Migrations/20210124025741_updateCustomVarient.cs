using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEInvoice.Migrations
{
    public partial class updateCustomVarient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Cgst",
                table: "CustomVarient",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCgstOnly",
                table: "CustomVarient",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Sgst",
                table: "CustomVarient",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDetails_BusinessAddress",
                table: "BusinessDetails",
                column: "BusinessAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessDetails_Address_BusinessAddress",
                table: "BusinessDetails",
                column: "BusinessAddress",
                principalTable: "Address",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessDetails_Address_BusinessAddress",
                table: "BusinessDetails");

            migrationBuilder.DropIndex(
                name: "IX_BusinessDetails_BusinessAddress",
                table: "BusinessDetails");

            migrationBuilder.DropColumn(
                name: "Cgst",
                table: "CustomVarient");

            migrationBuilder.DropColumn(
                name: "IsCgstOnly",
                table: "CustomVarient");

            migrationBuilder.DropColumn(
                name: "Sgst",
                table: "CustomVarient");
        }
    }
}
