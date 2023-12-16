using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sdfsdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_module_permission_credentials_credential_temp_id1",
                table: "module_permission");

            migrationBuilder.DropPrimaryKey(
                name: "pk_module_permission",
                table: "module_permission");

            migrationBuilder.DropIndex(
                name: "ix_module_permission_credential_id",
                table: "module_permission");

            migrationBuilder.DropColumn(
                name: "access",
                table: "module_permission");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "module_permission");

            migrationBuilder.DropColumn(
                name: "modified_date",
                table: "module_permission");

            migrationBuilder.DropColumn(
                name: "name",
                table: "module_permission");

            migrationBuilder.DropColumn(
                name: "permission",
                table: "credentials");

            migrationBuilder.AlterColumn<int>(
                name: "credential_id",
                table: "module_permission",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "module_permission",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "pk_module_permission",
                table: "module_permission",
                columns: new[] { "credential_id", "id" });

            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    credential_id = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permission", x => new { x.credential_id, x.id });
                    table.ForeignKey(
                        name: "fk_permission_credentials_credential_temp_id2",
                        column: x => x.credential_id,
                        principalTable: "credentials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "fk_module_permission_credentials_credential_temp_id1",
                table: "module_permission",
                column: "credential_id",
                principalTable: "credentials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_module_permission_credentials_credential_temp_id1",
                table: "module_permission");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropPrimaryKey(
                name: "pk_module_permission",
                table: "module_permission");

            migrationBuilder.DropColumn(
                name: "type",
                table: "module_permission");

            migrationBuilder.AlterColumn<int>(
                name: "credential_id",
                table: "module_permission",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "access",
                table: "module_permission",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "module_permission",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "modified_date",
                table: "module_permission",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "module_permission",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "permission",
                table: "credentials",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "pk_module_permission",
                table: "module_permission",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_module_permission_credential_id",
                table: "module_permission",
                column: "credential_id");

            migrationBuilder.AddForeignKey(
                name: "fk_module_permission_credentials_credential_temp_id1",
                table: "module_permission",
                column: "credential_id",
                principalTable: "credentials",
                principalColumn: "id");
        }
    }
}
