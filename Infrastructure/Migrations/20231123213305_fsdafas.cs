using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fsdafas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "job_position_id",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_users_job_position_id",
                table: "users",
                column: "job_position_id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_job_positions_job_position_temp_id",
                table: "users",
                column: "job_position_id",
                principalTable: "jobPositions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_job_positions_job_position_temp_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_job_position_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "job_position_id",
                table: "users");
        }
    }
}
