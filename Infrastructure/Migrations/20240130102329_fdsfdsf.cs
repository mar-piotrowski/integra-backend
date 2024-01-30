using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fdsfdsf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tax_id",
                table: "articles");

            migrationBuilder.AddColumn<decimal>(
                name: "tax",
                table: "articles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tax",
                table: "articles");

            migrationBuilder.AddColumn<int>(
                name: "tax_id",
                table: "articles",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
