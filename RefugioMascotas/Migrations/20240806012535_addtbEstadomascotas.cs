using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RefugioMascotas.Migrations
{
    /// <inheritdoc />
    public partial class addtbEstadomascotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstadoAdopcions",
                columns: table => new
                {
                    IdEstadoAdopcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstadodeAdopcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoAdopcions", x => x.IdEstadoAdopcion);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sexo",
                columns: table => new
                {
                    IdSexo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoSexo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sexo", x => x.IdSexo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoMascotas",
                columns: table => new
                {
                    IdTipoMascota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Especie = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Raza = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMascotas", x => x.IdTipoMascota);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "adoptantes",
                columns: table => new
                {
                    IdAdoptante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdSexo = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adoptantes", x => x.IdAdoptante);
                    table.ForeignKey(
                        name: "FK_adoptantes_sexo_IdSexo",
                        column: x => x.IdSexo,
                        principalTable: "sexo",
                        principalColumn: "IdSexo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdSexo = table.Column<int>(type: "int", nullable: false),
                    Cargo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleados", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK_empleados_sexo_IdSexo",
                        column: x => x.IdSexo,
                        principalTable: "sexo",
                        principalColumn: "IdSexo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mascotas",
                columns: table => new
                {
                    IdMascota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Edad = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SexoMascota = table.Column<int>(type: "int", nullable: false),
                    IdTipoMascota = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateOnly>(type: "date", nullable: true),
                    IdEstadoAdopcion = table.Column<int>(type: "int", nullable: false),
                    FotoMascota = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotas", x => x.IdMascota);
                    table.ForeignKey(
                        name: "FK_Mascotas_EstadoAdopcions_IdEstadoAdopcion",
                        column: x => x.IdEstadoAdopcion,
                        principalTable: "EstadoAdopcions",
                        principalColumn: "IdEstadoAdopcion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mascotas_TipoMascotas_IdTipoMascota",
                        column: x => x.IdTipoMascota,
                        principalTable: "TipoMascotas",
                        principalColumn: "IdTipoMascota",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mascotas_sexo_SexoMascota",
                        column: x => x.SexoMascota,
                        principalTable: "sexo",
                        principalColumn: "IdSexo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "adopcions",
                columns: table => new
                {
                    IdAdopcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaAdopcion = table.Column<DateOnly>(type: "date", nullable: false),
                    IdMascota = table.Column<int>(type: "int", nullable: false),
                    IdAdoptante = table.Column<int>(type: "int", nullable: false),
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adopcions", x => x.IdAdopcion);
                    table.ForeignKey(
                        name: "FK_adopcions_Mascotas_IdMascota",
                        column: x => x.IdMascota,
                        principalTable: "Mascotas",
                        principalColumn: "IdMascota",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_adopcions_adoptantes_IdAdoptante",
                        column: x => x.IdAdoptante,
                        principalTable: "adoptantes",
                        principalColumn: "IdAdoptante",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_adopcions_empleados_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "empleados",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cuidadoMedicos",
                columns: table => new
                {
                    IdCuidadoMedico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstadoSalud = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tratamiento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MascotaIdMascota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuidadoMedicos", x => x.IdCuidadoMedico);
                    table.ForeignKey(
                        name: "FK_cuidadoMedicos_Mascotas_MascotaIdMascota",
                        column: x => x.MascotaIdMascota,
                        principalTable: "Mascotas",
                        principalColumn: "IdMascota",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_adopcions_IdAdoptante",
                table: "adopcions",
                column: "IdAdoptante");

            migrationBuilder.CreateIndex(
                name: "IX_adopcions_IdEmpleado",
                table: "adopcions",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_adopcions_IdMascota",
                table: "adopcions",
                column: "IdMascota");

            migrationBuilder.CreateIndex(
                name: "IX_adoptantes_IdSexo",
                table: "adoptantes",
                column: "IdSexo");

            migrationBuilder.CreateIndex(
                name: "IX_cuidadoMedicos_MascotaIdMascota",
                table: "cuidadoMedicos",
                column: "MascotaIdMascota");

            migrationBuilder.CreateIndex(
                name: "IX_empleados_IdSexo",
                table: "empleados",
                column: "IdSexo");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_IdEstadoAdopcion",
                table: "Mascotas",
                column: "IdEstadoAdopcion");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_IdTipoMascota",
                table: "Mascotas",
                column: "IdTipoMascota");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_SexoMascota",
                table: "Mascotas",
                column: "SexoMascota");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adopcions");

            migrationBuilder.DropTable(
                name: "cuidadoMedicos");

            migrationBuilder.DropTable(
                name: "adoptantes");

            migrationBuilder.DropTable(
                name: "empleados");

            migrationBuilder.DropTable(
                name: "Mascotas");

            migrationBuilder.DropTable(
                name: "EstadoAdopcions");

            migrationBuilder.DropTable(
                name: "TipoMascotas");

            migrationBuilder.DropTable(
                name: "sexo");
        }
    }
}
