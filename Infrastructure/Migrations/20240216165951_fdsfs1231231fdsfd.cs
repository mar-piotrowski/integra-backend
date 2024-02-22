using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fdsfs1231231fdsfd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_working_times");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "start_date",
                table: "working_times",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "end_date",
                table: "working_times",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "working_times",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "working_times",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_working_times_user_id",
                table: "working_times",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_working_times_users_user_temp_id8",
                table: "working_times",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_working_times_users_user_temp_id8",
                table: "working_times");

            migrationBuilder.DropIndex(
                name: "ix_working_times_user_id",
                table: "working_times");

            migrationBuilder.DropColumn(
                name: "status",
                table: "working_times");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "working_times");

            migrationBuilder.AlterColumn<DateTime>(
                name: "start_date",
                table: "working_times",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                table: "working_times",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "user_working_times",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    working_time_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_working_times", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_working_times_users_user_temp_id8",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_working_times_working_times_working_time_temp_id",
                        column: x => x.working_time_id,
                        principalTable: "working_times",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_working_times_user_id",
                table: "user_working_times",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_working_times_working_time_id",
                table: "user_working_times",
                column: "working_time_id");
        }
    }
}
