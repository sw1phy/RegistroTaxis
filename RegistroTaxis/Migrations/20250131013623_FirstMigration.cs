using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTaxis.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Taxis",
                columns: table => new
                {
                    TaxiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Placa = table.Column<string>(type: "varchar(255)", nullable: false),
                    Observacion = table.Column<string>(type: "varchar(255)", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxis", x => x.TaxiId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreUsuario = table.Column<string>(type: "varchar(255)", nullable: false),
                    Contraseña = table.Column<string>(type: "varchar(255)", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "RegistroDiario",
                columns: table => new
                {
                    RegistroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalDia = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Combustible = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PagoBase = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PagoConductor = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PagoDueño = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Gastos = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Observacion = table.Column<string>(type: "varchar(255)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroDiario", x => x.RegistroId);
                    table.ForeignKey(
                        name: "FK_RegistroDiario_Taxis_TaxiId",
                        column: x => x.TaxiId,
                        principalTable: "Taxis",
                        principalColumn: "TaxiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroDiario_TaxiId",
                table: "RegistroDiario",
                column: "TaxiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroDiario");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Taxis");
        }
    }
}
