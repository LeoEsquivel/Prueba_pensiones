using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaNomina.Migrations
{
    /// <inheritdoc />
    public partial class CreandoTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Movimiento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Pensiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Pensiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pensionados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Noactivo = table.Column<int>(name: "No_activo", type: "int", maxLength: 50, nullable: false),
                    Statuspago = table.Column<bool>(name: "Status_pago", type: "bit", nullable: false),
                    Clavepension = table.Column<string>(name: "Clave_pension", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Noafiliado = table.Column<int>(name: "No_afiliado", type: "int", nullable: false),
                    Nopension = table.Column<int>(name: "No_pension", type: "int", nullable: false),
                    Sexo = table.Column<bool>(type: "bit", nullable: false),
                    ApellidoP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApellidoM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fechanacimiento = table.Column<DateTime>(name: "Fecha_nacimiento", type: "datetime2", nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    CURP = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstadocivilId = table.Column<int>(name: "Estado_civilId", type: "int", nullable: false),
                    TipoPensionId = table.Column<int>(name: "Tipo_PensionId", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pensionados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pensionados_Estados_Civiles_Estado_civilId",
                        column: x => x.EstadocivilId,
                        principalTable: "Estados_Civiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pensionados_Tipo_Pensiones_Tipo_PensionId",
                        column: x => x.TipoPensionId,
                        principalTable: "Tipo_Pensiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimientos_Pensionados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PensionadoId = table.Column<int>(type: "int", nullable: false),
                    MovimientosId = table.Column<int>(type: "int", nullable: false),
                    Importe = table.Column<float>(type: "real", nullable: false),
                    Fechainicio = table.Column<DateTime>(name: "Fecha_inicio", type: "datetime2", nullable: false),
                    Fechafinal = table.Column<DateTime>(name: "Fecha_final", type: "datetime2", nullable: false),
                    Tipo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos_Pensionados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimientos_Pensionados_Movimientos_MovimientosId",
                        column: x => x.MovimientosId,
                        principalTable: "Movimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimientos_Pensionados_Pensionados_PensionadoId",
                        column: x => x.PensionadoId,
                        principalTable: "Pensionados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_Pensionados_MovimientosId",
                table: "Movimientos_Pensionados",
                column: "MovimientosId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_Pensionados_PensionadoId",
                table: "Movimientos_Pensionados",
                column: "PensionadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pensionados_Estado_civilId",
                table: "Pensionados",
                column: "Estado_civilId");

            migrationBuilder.CreateIndex(
                name: "IX_Pensionados_Tipo_PensionId",
                table: "Pensionados",
                column: "Tipo_PensionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimientos_Pensionados");

            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "Pensionados");

            migrationBuilder.DropTable(
                name: "Tipo_Pensiones");
        }
    }
}
