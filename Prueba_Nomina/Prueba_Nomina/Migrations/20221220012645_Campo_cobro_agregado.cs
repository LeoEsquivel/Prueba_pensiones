using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaNomina.Migrations
{
    /// <inheritdoc />
    public partial class Campocobroagregado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Cobro_indebido",
                table: "Pensionados",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cobro_indebido",
                table: "Pensionados");
        }
    }
}
