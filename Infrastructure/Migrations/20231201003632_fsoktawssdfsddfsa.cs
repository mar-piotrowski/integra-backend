using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fsoktawssdfsddfsa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_holiday_limits_users_user_id",
                table: "holidayLimits");

            migrationBuilder.DropForeignKey(
                name: "fk_job_histories_users_user_temp_id2",
                table: "jobHistories");

            migrationBuilder.DropForeignKey(
                name: "fk_locations_users_user_temp_id3",
                table: "locations");

            migrationBuilder.DropForeignKey(
                name: "fk_school_histories_users_user_temp_id4",
                table: "schoolHistories");

            migrationBuilder.DropIndex(
                name: "ix_holiday_limits_user_id",
                table: "holidayLimits");

            migrationBuilder.CreateIndex(
                name: "ix_holiday_limits_user_id",
                table: "holidayLimits",
                column: "user_id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropIndex(
                name: "ix_holiday_limits_user_id",
                table: "holidayLimits");

            migrationBuilder.CreateIndex(
                name: "ix_holiday_limits_user_id",
                table: "holidayLimits",
                column: "user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_holiday_limits_users_user_id",
                table: "holidayLimits",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_job_histories_users_user_temp_id2",
                table: "jobHistories",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_locations_users_user_temp_id3",
                table: "locations",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_school_histories_users_user_temp_id4",
                table: "schoolHistories",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
