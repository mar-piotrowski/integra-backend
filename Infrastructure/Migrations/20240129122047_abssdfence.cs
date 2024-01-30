using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class abssdfence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_absence_status_absences_absence_id",
                table: "absence_status");

            migrationBuilder.DropIndex(
                name: "ix_absence_status_absence_id",
                table: "absence_status");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "absences",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "absences");

            migrationBuilder.CreateIndex(
                name: "ix_absence_status_absence_id",
                table: "absence_status",
                column: "absence_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_absence_status_absences_absence_id",
                table: "absence_status",
                column: "absence_id",
                principalTable: "absences",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
