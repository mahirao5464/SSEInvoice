using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEInvoice.Migrations
{
    public partial class AddVarientToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CGST",
                table: "Varients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "Price",
                table: "Varients",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "SGST",
                table: "Varients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Varients",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CGST",
                table: "Varients");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Varients");

            migrationBuilder.DropColumn(
                name: "SGST",
                table: "Varients");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Varients");
        }
    }
}
