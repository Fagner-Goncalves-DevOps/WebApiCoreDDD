using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class ajustepkid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TabTelecomConsolidado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Dia = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Fila = table.Column<int>(type: "int", nullable: false),
                    Terminator = table.Column<string>(type: "varchar(100)", nullable: false),
                    StatusInicial = table.Column<string>(type: "varchar(255)", nullable: false),
                    StatusFinal = table.Column<string>(type: "varchar(100)", nullable: false),
                    Disparos = table.Column<int>(type: "int", nullable: false),
                    Custo = table.Column<decimal>(type: "decimal (18,2)", nullable: false),
                    Servidor = table.Column<string>(type: "varchar(100)", nullable: false)
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
