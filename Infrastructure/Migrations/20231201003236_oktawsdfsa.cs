using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class oktawsdfsa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_holiday_limits_users_user_id",
                table: "holidayLimits");

            migrationBuilder.DropIndex(
                name: "ix_holiday_limits_user_id",
                table: "holidayLimits");
        }
    }
}
