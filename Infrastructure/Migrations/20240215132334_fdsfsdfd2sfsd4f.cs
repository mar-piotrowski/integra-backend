using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fdsfsdfd2sfsd4f : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_contractors_locations_location_temp_id",
                table: "contractors");

            migrationBuilder.DropIndex(
                name: "ix_contractors_location_id",
                table: "contractors");

            migrationBuilder.DropColumn(
                name: "location_id",
                table: "contractors");

            migrationBuilder.AddColumn<int>(
                name: "contractor_id",
                table: "locations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_locations_contractor_id",
                table: "locations",
                column: "contractor_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_locations_contractors_contractor_id",
                table: "locations",
                column: "contractor_id",
                principalTable: "contractors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_locations_contractors_contractor_id",
                table: "locations");

            migrationBuilder.DropIndex(
                name: "ix_locations_contractor_id",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "contractor_id",
                table: "locations");

            migrationBuilder.AddColumn<int>(
                name: "location_id",
                table: "contractors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_contractors_location_id",
                table: "contractors",
                column: "location_id");

            migrationBuilder.AddForeignKey(
                name: "fk_contractors_locations_location_temp_id",
                table: "contractors",
                column: "location_id",
                principalTable: "locations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
