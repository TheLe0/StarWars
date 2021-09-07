using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class TransactionTotalAmountField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total_to_pay",
                schema: "store",
                table: "transactions"
            );

            migrationBuilder.AddColumn<double>(
                name: "total_amount",
                schema: "store",
                table: "transactions",
                defaultValue: 0.00);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total_amount",
                schema: "store",
                table: "transactions"
            );
        }
    }
}
