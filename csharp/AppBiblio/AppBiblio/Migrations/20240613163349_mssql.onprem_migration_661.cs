using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppBiblio.Migrations
{
    /// <inheritdoc />
    public partial class mssqlonprem_migration_661 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "misLibros",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isbn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    editorial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idioma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_misLibros", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "misLibros");
        }
    }
}
