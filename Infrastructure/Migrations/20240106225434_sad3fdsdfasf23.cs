using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sad3fdsdfasf23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_contract_changes_contracts_contract_changed_temp_id1",
                table: "contractChanges");

            migrationBuilder.DropForeignKey(
                name: "fk_contract_changes_contracts_contract_temp_id",
                table: "contractChanges");

            migrationBuilder.DropForeignKey(
                name: "fk_schedules_users_user_temp_id8",
                table: "schedules");

            migrationBuilder.CreateTable(
                name: "user_contracts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    contract_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_contracts", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_contracts_contracts_contract_temp_id",
                        column: x => x.contract_id,
                        principalTable: "contracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_contracts_users_user_temp_id8",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_contracts_contract_id",
                table: "user_contracts",
                column: "contract_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_contracts_user_id",
                table: "user_contracts",
                column: "user_id");

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

            migrationBuilder.AddForeignKey(
                name: "fk_schedules_users_user_temp_id9",
                table: "schedules",
                column: "user_id",
                principalTable: "users",
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

            migrationBuilder.DropForeignKey(
                name: "fk_schedules_users_user_temp_id9",
                table: "schedules");

            migrationBuilder.DropTable(
                name: "user_contracts");

            migrationBuilder.AddForeignKey(
                name: "fk_contract_changes_contracts_contract_changed_temp_id1",
                table: "contractChanges",
                column: "contract_change_id",
                principalTable: "contracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_contract_changes_contracts_contract_temp_id",
                table: "contractChanges",
                column: "contract_id",
                principalTable: "contracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_schedules_users_user_temp_id8",
                table: "schedules",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
