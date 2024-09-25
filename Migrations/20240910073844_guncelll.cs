using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppBaslangc.Migrations
{
    public partial class guncelll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Mevcut UsersA tablosuna yeni sütunlar ekle
            //migrationBuilder.AddColumn<DateTime>(
            //    name: "CreatedDate",
            //    table: "UsersA",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: DateTime.UtcNow);

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "UpdatedDate",
            //    table: "UsersA",
            //    type: "datetime2",
            //    nullable: true);

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "DeletedDate",
            //    table: "UsersA",
            //    type: "datetime2",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsDeleted",
            //    table: "UsersA",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);
            migrationBuilder.AddColumn<byte[]>(
           name: "ImageData",
           table: "bicyles",
           type: "varbinary(max)",
           nullable: false,
           defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eklenen sütunları geri al
            //migrationBuilder.DropColumn(
            //    name: "CreatedDate",
            //    table: "UsersA");

            //migrationBuilder.DropColumn(
            //    name: "UpdatedDate",
            //    table: "UsersA");

            //migrationBuilder.DropColumn(
            //    name: "DeletedDate",
            //    table: "UsersA");

            //migrationBuilder.DropColumn(
            //    name: "IsDeleted",
            //    table: "UsersA");
            migrationBuilder.DropColumn(
           name: "ImageData",
           table: "bicyles");
        }
    }
}
