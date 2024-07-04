using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inmobiliaria.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inmuebles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _metros = table.Column<int>(type: "int", nullable: false),
                    _esNuevo = table.Column<bool>(type: "bit", nullable: false),
                    _base = table.Column<double>(type: "float", nullable: false),
                    _fechaConstruccion = table.Column<DateOnly>(type: "date", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    _nroVentanas = table.Column<int>(type: "int", nullable: true),
                    _planta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmuebles", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inmuebles");
        }
    }
}
