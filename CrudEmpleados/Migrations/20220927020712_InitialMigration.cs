using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudEmpleados.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sCorreo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dtFechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtFechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleados", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empleados");
        }
    }
}
