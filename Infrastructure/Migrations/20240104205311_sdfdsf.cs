using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sdfdsf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cards_users_user_temp_id6",
                table: "cards");

            migrationBuilder.DropForeignKey(
                name: "fk_contracts_users_user_temp_id1",
                table: "contracts");

            migrationBuilder.DropForeignKey(
                name: "fk_holiday_limits_users_user_temp_id2",
                table: "holidayLimits");

            migrationBuilder.DropForeignKey(
                name: "fk_job_histories_users_user_temp_id3",
                table: "jobHistories");

            migrationBuilder.DropForeignKey(
                name: "fk_locations_users_user_temp_id4",
                table: "locations");

            migrationBuilder.DropForeignKey(
                name: "fk_school_histories_users_user_temp_id5",
                table: "schoolHistories");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "cards",
                newName: "is_active");

            migrationBuilder.AddForeignKey(
                name: "fk_cards_users_user_temp_id1",
                table: "cards",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_contracts_users_user_temp_id2",
                table: "contracts",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_holiday_limits_users_user_temp_id3",
                table: "holidayLimits",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_job_histories_users_user_temp_id4",
                table: "jobHistories",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_locations_users_user_temp_id5",
                table: "locations",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_school_histories_users_user_temp_id6",
                table: "schoolHistories",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cards_users_user_temp_id1",
                table: "cards");

            migrationBuilder.DropForeignKey(
                name: "fk_contracts_users_user_temp_id2",
                table: "contracts");

            migrationBuilder.DropForeignKey(
                name: "fk_holiday_limits_users_user_temp_id3",
                table: "holidayLimits");

            migrationBuilder.DropForeignKey(
                name: "fk_job_histories_users_user_temp_id4",
                table: "jobHistories");

            migrationBuilder.DropForeignKey(
                name: "fk_locations_users_user_temp_id5",
                table: "locations");

            migrationBuilder.DropForeignKey(
                name: "fk_school_histories_users_user_temp_id6",
                table: "schoolHistories");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "cards",
                newName: "active");

            migrationBuilder.AddForeignKey(
                name: "fk_cards_users_user_temp_id6",
                table: "cards",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_contracts_users_user_temp_id1",
                table: "contracts",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_holiday_limits_users_user_temp_id2",
                table: "holidayLimits",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_job_histories_users_user_temp_id3",
                table: "jobHistories",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_locations_users_user_temp_id4",
                table: "locations",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_school_histories_users_user_temp_id5",
                table: "schoolHistories",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
