using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sdfds323f : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cards_users_user_temp_id9",
                table: "cards");

            migrationBuilder.DropForeignKey(
                name: "fk_contracts_users_user_temp_id1",
                table: "contracts");

            migrationBuilder.DropForeignKey(
                name: "fk_holiday_limits_users_user_temp_id2",
                table: "holiday_limits");

            migrationBuilder.DropForeignKey(
                name: "fk_job_histories_users_user_temp_id3",
                table: "job_histories");

            migrationBuilder.DropForeignKey(
                name: "fk_locations_users_user_temp_id4",
                table: "locations");

            migrationBuilder.DropForeignKey(
                name: "fk_school_histories_users_user_temp_id7",
                table: "school_histories");

            migrationBuilder.DropForeignKey(
                name: "fk_user_permissions_users_user_temp_id5",
                table: "user_permissions");

            migrationBuilder.DropForeignKey(
                name: "fk_user_schedules_users_user_temp_id6",
                table: "user_schedules");

            migrationBuilder.DropForeignKey(
                name: "fk_working_times_users_user_temp_id8",
                table: "working_times");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "assignment_date",
                table: "cards",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

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
                table: "holiday_limits",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_job_histories_users_user_temp_id4",
                table: "job_histories",
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
                name: "fk_school_histories_users_user_temp_id8",
                table: "school_histories",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_permissions_users_user_temp_id6",
                table: "user_permissions",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_schedules_users_user_temp_id7",
                table: "user_schedules",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_working_times_users_user_temp_id9",
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
                name: "fk_cards_users_user_temp_id1",
                table: "cards");

            migrationBuilder.DropForeignKey(
                name: "fk_contracts_users_user_temp_id2",
                table: "contracts");

            migrationBuilder.DropForeignKey(
                name: "fk_holiday_limits_users_user_temp_id3",
                table: "holiday_limits");

            migrationBuilder.DropForeignKey(
                name: "fk_job_histories_users_user_temp_id4",
                table: "job_histories");

            migrationBuilder.DropForeignKey(
                name: "fk_locations_users_user_temp_id5",
                table: "locations");

            migrationBuilder.DropForeignKey(
                name: "fk_school_histories_users_user_temp_id8",
                table: "school_histories");

            migrationBuilder.DropForeignKey(
                name: "fk_user_permissions_users_user_temp_id6",
                table: "user_permissions");

            migrationBuilder.DropForeignKey(
                name: "fk_user_schedules_users_user_temp_id7",
                table: "user_schedules");

            migrationBuilder.DropForeignKey(
                name: "fk_working_times_users_user_temp_id9",
                table: "working_times");

            migrationBuilder.DropColumn(
                name: "assignment_date",
                table: "cards");

            migrationBuilder.AddForeignKey(
                name: "fk_cards_users_user_temp_id9",
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
                table: "holiday_limits",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_job_histories_users_user_temp_id3",
                table: "job_histories",
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
                name: "fk_school_histories_users_user_temp_id7",
                table: "school_histories",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_permissions_users_user_temp_id5",
                table: "user_permissions",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_schedules_users_user_temp_id6",
                table: "user_schedules",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_working_times_users_user_temp_id8",
                table: "working_times",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
