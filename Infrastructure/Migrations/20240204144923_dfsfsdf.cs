using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dfsfsdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_articles_stocks_stock_temp_id",
                table: "articles");

            migrationBuilder.DropForeignKey(
                name: "fk_stocks_locations_location_temp_id1",
                table: "stocks");

            migrationBuilder.DropIndex(
                name: "ix_stocks_locationid",
                table: "stocks");

            migrationBuilder.DropIndex(
                name: "ix_articles_stock_id",
                table: "articles");

            migrationBuilder.DropColumn(
                name: "locationid",
                table: "stocks");

            migrationBuilder.DropColumn(
                name: "stock_amount",
                table: "articles");

            migrationBuilder.DropColumn(
                name: "stock_id",
                table: "articles");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "stocks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_main",
                table: "stocks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "stock_articles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stock_id = table.Column<int>(type: "integer", nullable: false),
                    article_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stock_articles", x => x.id);
                    table.ForeignKey(
                        name: "fk_stock_articles_articles_article_temp_id1",
                        column: x => x.article_id,
                        principalTable: "articles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_stock_articles_stocks_stock_temp_id",
                        column: x => x.stock_id,
                        principalTable: "stocks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_stock_articles_article_id",
                table: "stock_articles",
                column: "article_id");

            migrationBuilder.CreateIndex(
                name: "ix_stock_articles_stock_id",
                table: "stock_articles",
                column: "stock_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stock_articles");

            migrationBuilder.DropColumn(
                name: "description",
                table: "stocks");

            migrationBuilder.DropColumn(
                name: "is_main",
                table: "stocks");

            migrationBuilder.AddColumn<int>(
                name: "locationid",
                table: "stocks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "stock_amount",
                table: "articles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "stock_id",
                table: "articles",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_stocks_locationid",
                table: "stocks",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "ix_articles_stock_id",
                table: "articles",
                column: "stock_id");

            migrationBuilder.AddForeignKey(
                name: "fk_articles_stocks_stock_temp_id",
                table: "articles",
                column: "stock_id",
                principalTable: "stocks",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_stocks_locations_location_temp_id1",
                table: "stocks",
                column: "locationid",
                principalTable: "locations",
                principalColumn: "id");
        }
    }
}
