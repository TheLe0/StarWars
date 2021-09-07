using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class PurchaseAmountChangeToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "value",
                schema: "store",
                table: "purchases"
            );

            migrationBuilder.AddColumn<double>(
                name: "value",
                schema: "store",
                table: "purchases",
                nullable: false,
                defaultValue: 0.00
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "value",
                schema: "store",
                table: "purchases",
                nullable: false,
                defaultValue: 0.00
            );
        }
    }
}
