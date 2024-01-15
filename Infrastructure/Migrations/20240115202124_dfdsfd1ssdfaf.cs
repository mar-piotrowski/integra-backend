using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dfdsfd1ssdfaf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "commune",
                table: "locations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "district",
                table: "locations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "province",
                table: "locations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "contractors",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "commune",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "district",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "province",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "contractors");
        }
    }
}
