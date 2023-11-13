using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dasfasasdfaddfa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankDetailsid",
                table: "contractors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "bankDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankDetails", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contractors_BankDetailsid",
                table: "contractors",
                column: "BankDetailsid");

            migrationBuilder.AddForeignKey(
                name: "FK_contractors_bankDetails_BankDetailsid",
                table: "contractors",
                column: "BankDetailsid",
                principalTable: "bankDetails",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contractors_bankDetails_BankDetailsid",
                table: "contractors");

            migrationBuilder.DropTable(
                name: "bankDetails");

            migrationBuilder.DropIndex(
                name: "IX_contractors_BankDetailsid",
                table: "contractors");

            migrationBuilder.DropColumn(
                name: "BankDetailsid",
                table: "contractors");
        }
    }
}
