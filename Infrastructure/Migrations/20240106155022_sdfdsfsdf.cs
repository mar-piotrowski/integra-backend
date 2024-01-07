using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sdfdsfsdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_credentials_credential_temp_id2",
                table: "users");

            migrationBuilder.DropTable(
                name: "module_permission");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<int>(type: "integer", nullable: false),
                    card_id = table.Column<int>(type: "integer", nullable: true),
                    credential_id = table.Column<int>(type: "integer", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_permissions_cards_card_temp_id",
                        column: x => x.card_id,
                        principalTable: "cards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_permissions_credentials_credential_temp_id",
                        column: x => x.credential_id,
                        principalTable: "credentials",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_permissions_card_id",
                table: "permissions",
                column: "card_id");

            migrationBuilder.CreateIndex(
                name: "ix_permissions_credential_id",
                table: "permissions",
                column: "credential_id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_credentials_credential_temp_id1",
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
                name: "fk_users_credentials_credential_temp_id1",
                table: "users");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.CreateTable(
                name: "module_permission",
                columns: table => new
                {
                    credential_id = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_module_permission", x => new { x.credential_id, x.id });
                    table.ForeignKey(
                        name: "fk_module_permission_credentials_credential_temp_id",
                        column: x => x.credential_id,
                        principalTable: "credentials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "fk_permission_credentials_credential_temp_id1",
                        column: x => x.credential_id,
                        principalTable: "credentials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "fk_users_credentials_credential_temp_id2",
                table: "users",
                column: "credential_id",
                principalTable: "credentials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
