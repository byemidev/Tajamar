using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inmobiliaria.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    metros = table.Column<int>(type: "int", nullable: true),
                    es_nuevo = table.Column<bool>(type: "bit", nullable: true),
                    precio_base = table.Column<double>(type: "float", nullable: true),
                    fecha_construccion = table.Column<DateOnly>(type: "date", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    nro_ventanas = table.Column<int>(type: "int", nullable: true),
                    planta = table.Column<int>(type: "int", nullable: true)
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
