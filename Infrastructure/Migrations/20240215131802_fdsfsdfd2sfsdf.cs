using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fdsfsdfd2sfsdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_contractors_bank_accounts_bank_account_temp_id1",
                table: "contractors");

            migrationBuilder.DropIndex(
                name: "ix_contractors_bank_account_id",
                table: "contractors");

            migrationBuilder.DropColumn(
                name: "bank_account_id",
                table: "contractors");

            migrationBuilder.AddColumn<int>(
                name: "contractor_id",
                table: "bank_accounts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_bank_accounts_contractor_id",
                table: "bank_accounts",
                column: "contractor_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_bank_accounts_contractors_contractor_id",
                table: "bank_accounts",
                column: "contractor_id",
                principalTable: "contractors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_bank_accounts_contractors_contractor_id",
                table: "bank_accounts");

            migrationBuilder.DropIndex(
                name: "ix_bank_accounts_contractor_id",
                table: "bank_accounts");

            migrationBuilder.DropColumn(
                name: "contractor_id",
                table: "bank_accounts");

            migrationBuilder.AddColumn<string>(
                name: "bank_account_id",
                table: "contractors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "ix_contractors_bank_account_id",
                table: "contractors",
                column: "bank_account_id");

            migrationBuilder.AddForeignKey(
                name: "fk_contractors_bank_accounts_bank_account_temp_id1",
                table: "contractors",
                column: "bank_account_id",
                principalTable: "bank_accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
