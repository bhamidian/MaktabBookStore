using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaktabBookStore.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class init2007 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "LogoPath",
                value: "images/Logos/novels.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "LogoPath",
                value: "images/Logos/vast.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "LogoPath",
                value: "images/Logos/brain.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "LogoPath",
                value: "images/Logos/philosophy.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "LogoPath",
                value: "images/Logos/art.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "LogoPath",
                value: "~/images/Logos/novels.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "LogoPath",
                value: "~/images/Logos/vast.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "LogoPath",
                value: "~/images/Logos/brain.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "LogoPath",
                value: "~/images/Logos/philosophy.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "LogoPath",
                value: "~/images/Logos/art.png");
        }
    }
}
