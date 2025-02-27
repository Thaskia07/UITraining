using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UITraining.Migrations
{
    /// <inheritdoc />
    public partial class updateProduk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "produks");

            migrationBuilder.AddColumn<int>(
                name: "ProductStatus",
                table: "produks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductStatus",
                table: "produks");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "produks",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
