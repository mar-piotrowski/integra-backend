using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fddff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_bank_accounts_contractors_contractor_id",
                table: "bank_accounts");

            migrationBuilder.AlterColumn<int>(
                name: "contractor_id",
                table: "bank_accounts",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "fk_bank_accounts_contractors_contractor_id",
                table: "bank_accounts",
                column: "contractor_id",
                principalTable: "contractors",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_bank_accounts_contractors_contractor_id",
                table: "bank_accounts");

            migrationBuilder.AlterColumn<int>(
                name: "contractor_id",
                table: "bank_accounts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_bank_accounts_contractors_contractor_id",
                table: "bank_accounts",
                column: "contractor_id",
                principalTable: "contractors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
