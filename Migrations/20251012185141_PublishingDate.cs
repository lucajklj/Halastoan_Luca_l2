using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Halastoan_Luca_l2.Migrations
{
    /// <inheritdoc />
    public partial class PublishingDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "book",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishingDate",
                table: "book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "book");

            migrationBuilder.DropColumn(
                name: "PublishingDate",
                table: "book");
        }
    }
}
