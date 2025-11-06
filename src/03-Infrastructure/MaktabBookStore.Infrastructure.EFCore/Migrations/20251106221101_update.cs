using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaktabBookStore.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Logo",
                table: "Categories",
                newName: "LogoPath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LogoPath",
                table: "Categories",
                newName: "Logo");
        }
    }
}
