using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEInvoice.Migrations
{
    public partial class quotaddressstringupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BillingAddressString",
                table: "Quotations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingAddressString",
                table: "Quotations");
        }
    }
}
