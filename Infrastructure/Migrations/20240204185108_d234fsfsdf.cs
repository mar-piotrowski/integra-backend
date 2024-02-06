using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class d234fsfsdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_documents_contractors_contractor_temp_id",
                table: "documents");

            migrationBuilder.DropForeignKey(
                name: "fk_stock_articles_stocks_stock_temp_id",
                table: "stock_articles");

            migrationBuilder.AlterColumn<int>(
                name: "contractor_id",
                table: "documents",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "source_stock_id",
                table: "documents",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "target_stock_id",
                table: "documents",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_documents_source_stock_id",
                table: "documents",
                column: "source_stock_id");

            migrationBuilder.CreateIndex(
                name: "ix_documents_target_stock_id",
                table: "documents",
                column: "target_stock_id");

            migrationBuilder.AddForeignKey(
                name: "fk_documents_contractors_contractor_temp_id",
                table: "documents",
                column: "contractor_id",
                principalTable: "contractors",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_documents_stocks_source_stock_temp_id",
                table: "documents",
                column: "source_stock_id",
                principalTable: "stocks",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_documents_stocks_target_stock_temp_id1",
                table: "documents",
                column: "target_stock_id",
                principalTable: "stocks",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_stock_articles_stocks_stock_temp_id2",
                table: "stock_articles",
                column: "stock_id",
                principalTable: "stocks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_documents_contractors_contractor_temp_id",
                table: "documents");

            migrationBuilder.DropForeignKey(
                name: "fk_documents_stocks_source_stock_temp_id",
                table: "documents");

            migrationBuilder.DropForeignKey(
                name: "fk_documents_stocks_target_stock_temp_id1",
                table: "documents");

            migrationBuilder.DropForeignKey(
                name: "fk_stock_articles_stocks_stock_temp_id2",
                table: "stock_articles");

            migrationBuilder.DropIndex(
                name: "ix_documents_source_stock_id",
                table: "documents");

            migrationBuilder.DropIndex(
                name: "ix_documents_target_stock_id",
                table: "documents");

            migrationBuilder.DropColumn(
                name: "source_stock_id",
                table: "documents");

            migrationBuilder.DropColumn(
                name: "target_stock_id",
                table: "documents");

            migrationBuilder.AlterColumn<int>(
                name: "contractor_id",
                table: "documents",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_documents_contractors_contractor_temp_id",
                table: "documents",
                column: "contractor_id",
                principalTable: "contractors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stock_articles_stocks_stock_temp_id",
                table: "stock_articles",
                column: "stock_id",
                principalTable: "stocks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
