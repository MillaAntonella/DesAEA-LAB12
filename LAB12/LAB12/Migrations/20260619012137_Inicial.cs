using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB12.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.IdEstudiante);
                });

            migrationBuilder.CreateTable(
                name: "Instructores",
                columns: table => new
                {
                    IdInstructor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructores", x => x.IdInstructor);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    IdCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    DuracionHoras = table.Column<int>(type: "int", nullable: false),
                    IdInstructor = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    InstructorIdInstructor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.IdCurso);
                    table.ForeignKey(
                        name: "FK_Cursos_Instructores_InstructorIdInstructor",
                        column: x => x.InstructorIdInstructor,
                        principalTable: "Instructores",
                        principalColumn: "IdInstructor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    IdMatricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstudiante = table.Column<int>(type: "int", nullable: false),
                    IdCurso = table.Column<int>(type: "int", nullable: false),
                    FechaMatricula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    EstudianteIdEstudiante = table.Column<int>(type: "int", nullable: false),
                    CursoIdCurso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.IdMatricula);
                    table.ForeignKey(
                        name: "FK_Matriculas_Cursos_CursoIdCurso",
                        column: x => x.CursoIdCurso,
                        principalTable: "Cursos",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matriculas_Estudiantes_EstudianteIdEstudiante",
                        column: x => x.EstudianteIdEstudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "IdEstudiante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMatricula = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MetodoPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatriculaIdMatricula = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.IdPago);
                    table.ForeignKey(
                        name: "FK_Pagos_Matriculas_MatriculaIdMatricula",
                        column: x => x.MatriculaIdMatricula,
                        principalTable: "Matriculas",
                        principalColumn: "IdMatricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_InstructorIdInstructor",
                table: "Cursos",
                column: "InstructorIdInstructor");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_CursoIdCurso",
                table: "Matriculas",
                column: "CursoIdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_EstudianteIdEstudiante",
                table: "Matriculas",
                column: "EstudianteIdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_MatriculaIdMatricula",
                table: "Pagos",
                column: "MatriculaIdMatricula");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Instructores");
        }
    }
}
