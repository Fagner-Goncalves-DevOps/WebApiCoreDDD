using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class inicialDbTelecom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TabTelecomConsolidado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dia = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Fila = table.Column<int>(type: "int", nullable: true),
                    Terminator = table.Column<string>(type: "varchar(100)", nullable: true),
                    StatusInicial = table.Column<string>(type: "varchar(255)", nullable: true),
                    StatusFinal = table.Column<string>(type: "varchar(100)", nullable: false),
                    Disparos = table.Column<int>(type: "int", nullable: false),
                    Custo = table.Column<decimal>(type: "decimal (18,2)", nullable: false),
                    Servidor = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabTelecomConsolidado", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabTelecomConsolidado");
        }
    }
}
