using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fdasfdsafasdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "users",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.AddColumn<string>(
                name: "identityNumber",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "locations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_locations_UserId",
                table: "locations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_locations_users_UserId",
                table: "locations",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locations_users_UserId",
                table: "locations");

            migrationBuilder.DropIndex(
                name: "IX_locations_UserId",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "identityNumber",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "locations");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");
        }
    }
}
