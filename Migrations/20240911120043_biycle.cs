using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppBaslangc.Migrations
{
    /// <inheritdoc />
    public partial class biycle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "bicyles",
            //    columns: table => new
            //    {
            //        ıd = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        model = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        year = table.Column<int>(type: "int", nullable: false),
            //        type = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        color = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_bicyles", x => x.ıd);
            //    });
            migrationBuilder.AddColumn<bool>(
             name: "IsDeleted",
             table: "bicyles",
             type: "bit",
             nullable: false,
             defaultValue: false); // Soft delete flag

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "bicyles",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()"); // Creation date

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "bicyles",
                type: "datetime2",
                nullable: true); // Last updated date

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "bicyles",
                type: "datetime2",
                nullable: true); // Deletion date
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "bicyles");
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "bicyles");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "bicyles");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "bicyles");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "bicyles");
        }
    }
}
