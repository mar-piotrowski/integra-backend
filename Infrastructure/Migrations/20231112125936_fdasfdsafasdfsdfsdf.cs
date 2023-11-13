using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fdasfdsafasdfsdfsdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_credentials_users_UserId",
                table: "credentials");

            migrationBuilder.DropIndex(
                name: "IX_credentials_UserId",
                table: "credentials");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "credentials");

            migrationBuilder.AddColumn<int>(
                name: "CredentialId",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_CredentialId",
                table: "users",
                column: "CredentialId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_credentials_CredentialId",
                table: "users",
                column: "CredentialId",
                principalTable: "credentials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_credentials_CredentialId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_CredentialId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CredentialId",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "credentials",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_credentials_UserId",
                table: "credentials",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_credentials_users_UserId",
                table: "credentials",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
