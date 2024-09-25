using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppBaslangc.Migrations
{
    /// <inheritdoc />
    public partial class bsbs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "bicyles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "bicyles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "bicyles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "bicyles",
                type: "datetime2",
                nullable: true);
            // Specify column type for 'price' column explicitly
            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "bicyles",
                type: "decimal(18, 2)", // Set precision and scale
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "bicyles");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "bicyles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "bicyles");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "bicyles");
            // Reverse column type changes if rolling back migration
            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "bicyles",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
