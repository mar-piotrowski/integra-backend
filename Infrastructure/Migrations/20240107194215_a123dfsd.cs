using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class a123dfsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_permissions_cards_card_temp_id",
                table: "permissions");

            migrationBuilder.DropForeignKey(
                name: "fk_permissions_credentials_credential_temp_id",
                table: "permissions");

            migrationBuilder.DropForeignKey(
                name: "fk_users_credentials_credential_temp_id1",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_permissions_card_id",
                table: "permissions");

            migrationBuilder.DropIndex(
                name: "ix_permissions_credential_id",
                table: "permissions");

            migrationBuilder.DropColumn(
                name: "card_id",
                table: "permissions");

            migrationBuilder.DropColumn(
                name: "credential_id",
                table: "permissions");

            migrationBuilder.AddForeignKey(
                name: "fk_users_credentials_credential_temp_id",
                table: "users",
                column: "credential_id",
                principalTable: "credentials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_credentials_credential_temp_id",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "card_id",
                table: "permissions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "credential_id",
                table: "permissions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_permissions_card_id",
                table: "permissions",
                column: "card_id");

            migrationBuilder.CreateIndex(
                name: "ix_permissions_credential_id",
                table: "permissions",
                column: "credential_id");

            migrationBuilder.AddForeignKey(
                name: "fk_permissions_cards_card_temp_id",
                table: "permissions",
                column: "card_id",
                principalTable: "cards",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_permissions_credentials_credential_temp_id",
                table: "permissions",
                column: "credential_id",
                principalTable: "credentials",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_credentials_credential_temp_id1",
                table: "users",
                column: "credential_id",
                principalTable: "credentials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
