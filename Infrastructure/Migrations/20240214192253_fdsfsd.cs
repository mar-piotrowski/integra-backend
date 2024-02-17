using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fdsfsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "locationid",
                table: "contractors",
                newName: "location_id");

            migrationBuilder.RenameIndex(
                name: "ix_contractors_locationid",
                table: "contractors",
                newName: "ix_contractors_location_id");

            migrationBuilder.AlterColumn<string>(
                name: "district",
                table: "locations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "locations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "modified_date",
                table: "locations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_date",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "modified_date",
                table: "locations");

            migrationBuilder.RenameColumn(
                name: "location_id",
                table: "contractors",
                newName: "locationid");

            migrationBuilder.RenameIndex(
                name: "ix_contractors_location_id",
                table: "contractors",
                newName: "ix_contractors_locationid");

            migrationBuilder.AlterColumn<string>(
                name: "district",
                table: "locations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
