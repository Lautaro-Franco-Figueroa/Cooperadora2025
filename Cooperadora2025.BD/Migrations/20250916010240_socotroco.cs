using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cooperadora2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class socotroco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "Alumnos_DNI_UQ",
                table: "Alumnos",
                column: "DNI",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Alumnos_DNI_UQ",
                table: "Alumnos");
        }
    }
}
