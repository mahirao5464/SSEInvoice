using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEInvoice.Migrations
{
    public partial class contactpersonnameadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactPersonName",
                table: "Customers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactPersonName",
                table: "Customers");
        }
    }
}
