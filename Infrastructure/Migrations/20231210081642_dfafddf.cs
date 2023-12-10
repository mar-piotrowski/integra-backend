using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dfafddf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_articles_stocks_stock_temp_id",
                table: "articles");

            migrationBuilder.AlterColumn<int>(
                name: "stock_id",
                table: "articles",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<decimal>(
                name: "buy_price_with_tax",
                table: "articles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "buy_price_without_tax",
                table: "articles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "sell_price_with_tax",
                table: "articles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "sell_price_without_tax",
                table: "articles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "tax_id",
                table: "articles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "fk_articles_stocks_stock_temp_id",
                table: "articles",
                column: "stock_id",
                principalTable: "stocks",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_articles_stocks_stock_temp_id",
                table: "articles");

            migrationBuilder.DropColumn(
                name: "buy_price_with_tax",
                table: "articles");

            migrationBuilder.DropColumn(
                name: "buy_price_without_tax",
                table: "articles");

            migrationBuilder.DropColumn(
                name: "sell_price_with_tax",
                table: "articles");

            migrationBuilder.DropColumn(
                name: "sell_price_without_tax",
                table: "articles");

            migrationBuilder.DropColumn(
                name: "tax_id",
                table: "articles");

            migrationBuilder.AlterColumn<int>(
                name: "stock_id",
                table: "articles",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_articles_stocks_stock_temp_id",
                table: "articles",
                column: "stock_id",
                principalTable: "stocks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
