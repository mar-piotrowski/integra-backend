using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inisdfdsfstsdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_contract_changes_contracts_contract_changed_temp_id",
                table: "contractChanges");

            migrationBuilder.DropIndex(
                name: "ix_contract_changes_contract_change_id",
                table: "contractChanges");

            migrationBuilder.CreateIndex(
                name: "ix_contract_changes_contract_change_id",
                table: "contractChanges",
                column: "contract_change_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_contract_changes_contracts_contract_changed_temp_id",
                table: "contractChanges",
                column: "contract_change_id",
                principalTable: "contracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_contract_changes_contracts_contract_changed_temp_id",
                table: "contractChanges");

            migrationBuilder.DropIndex(
                name: "ix_contract_changes_contract_change_id",
                table: "contractChanges");

            migrationBuilder.CreateIndex(
                name: "ix_contract_changes_contract_change_id",
                table: "contractChanges",
                column: "contract_change_id");

            migrationBuilder.AddForeignKey(
                name: "fk_contract_changes_contracts_contract_changed_temp_id",
                table: "contractChanges",
                column: "contract_change_id",
                principalTable: "contracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
