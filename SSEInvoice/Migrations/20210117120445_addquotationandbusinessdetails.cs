using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSEInvoice.Migrations
{
    public partial class addquotationandbusinessdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    BankName = table.Column<string>(nullable: false),
                    BranchName = table.Column<string>(nullable: false),
                    IFSC = table.Column<string>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    BillingTo = table.Column<int>(nullable: false),
                    QuotNumber = table.Column<string>(nullable: true),
                    SubTotal = table.Column<double>(nullable: false),
                    TotalTax = table.Column<double>(nullable: false),
                    ShippingCharges = table.Column<double>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessAddress = table.Column<int>(nullable: false),
                    GSTNumber = table.Column<string>(nullable: false),
                    BankDetailId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessDetails_BankDetail_BankDetailId",
                        column: x => x.BankDetailId,
                        principalTable: "BankDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomVarient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VarientId = table.Column<int>(nullable: false),
                    CustomePrice = table.Column<double>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    QuotationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomVarient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomVarient_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomVarient_Varients_VarientId",
                        column: x => x.VarientId,
                        principalTable: "Varients",
                        principalColumn: "VarientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessDetails_BankDetailId",
                table: "BusinessDetails",
                column: "BankDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomVarient_QuotationId",
                table: "CustomVarient",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomVarient_VarientId",
                table: "CustomVarient",
                column: "VarientId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_CustomerId",
                table: "Quotations",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessDetails");

            migrationBuilder.DropTable(
                name: "CustomVarient");

            migrationBuilder.DropTable(
                name: "BankDetail");

            migrationBuilder.DropTable(
                name: "Quotations");
        }
    }
}
