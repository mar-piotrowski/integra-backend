using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_usefffr_fsdfieldssdf2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_contract_changes_contracts_contract_changed_temp_id2",
                table: "contractChanges");

            migrationBuilder.DropForeignKey(
                name: "fk_contract_changes_contracts_contract_temp_id1",
                table: "contractChanges");

            migrationBuilder.AddForeignKey(
                name: "fk_contract_changes_contracts_contract_changed_temp_id2",
                table: "contractChanges",
                column: "contract_change_id",
                principalTable: "contracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_contract_changes_contracts_contract_temp_id1",
                table: "contractChanges",
                column: "contract_id",
                principalTable: "contracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_contract_changes_contracts_contract_changed_temp_id2",
                table: "contractChanges");

            migrationBuilder.DropForeignKey(
                name: "fk_contract_changes_contracts_contract_temp_id1",
                table: "contractChanges");

            migrationBuilder.AddForeignKey(
                name: "fk_contract_changes_contracts_contract_changed_temp_id2",
                table: "contractChanges",
                column: "contract_change_id",
                principalTable: "contracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_contract_changes_contracts_contract_temp_id1",
                table: "contractChanges",
                column: "contract_id",
                principalTable: "contracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
