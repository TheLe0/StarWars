using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "store");

            migrationBuilder.CreateTable(
                name: "credit_cards",
                schema: "store",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    card_number = table.Column<string>(type: "text", nullable: true),
                    card_holder_name = table.Column<string>(type: "text", nullable: true),
                    cvv = table.Column<string>(type: "text", nullable: true),
                    exp_date = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_credit_cards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "store",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    zipcode = table.Column<string>(type: "text", nullable: true),
                    seller = table.Column<string>(type: "text", nullable: true),
                    thumbnail_hd = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "purchases",
                schema: "store",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<string>(type: "text", nullable: true),
                    value = table.Column<string>(type: "text", nullable: true),
                    client_id = table.Column<string>(type: "text", nullable: true),
                    card_number = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchases", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "store",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                schema: "store",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    client_id = table.Column<Guid>(type: "uuid", nullable: false),
                    client_name = table.Column<string>(type: "text", nullable: true),
                    total_to_pay = table.Column<string>(type: "text", nullable: true),
                    creditcardid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_transactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_transactions_credit_cards_creditcardid",
                        column: x => x.creditcardid,
                        principalSchema: "store",
                        principalTable: "credit_cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_transactions_creditcardid",
                schema: "store",
                table: "transactions",
                column: "creditcardid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products",
                schema: "store");

            migrationBuilder.DropTable(
                name: "purchases",
                schema: "store");

            migrationBuilder.DropTable(
                name: "transactions",
                schema: "store");

            migrationBuilder.DropTable(
                name: "users",
                schema: "store");

            migrationBuilder.DropTable(
                name: "credit_cards",
                schema: "store");
        }
    }
}
