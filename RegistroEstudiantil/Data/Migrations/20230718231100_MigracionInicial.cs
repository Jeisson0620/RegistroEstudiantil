using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroEstudiantil.Data.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                schema: "dbo",
                columns: table => new
                {
                    IDEstudiantes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.IDEstudiantes);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                schema: "dbo",
                columns: table => new
                {
                    IDProfesores = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.IDProfesores);
                });

            migrationBuilder.CreateTable(
                name: "notas",
                schema: "dbo",
                columns: table => new
                {
                    IDNota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nota = table.Column<int>(type: "int", nullable: false),
                    IDEstudiantes = table.Column<int>(type: "int", nullable: false),
                    IDProfesores = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notas", x => x.IDNota);
                    table.ForeignKey(
                        name: "FK_notas_Estudiantes_IDEstudiantes",
                        column: x => x.IDEstudiantes,
                        principalSchema: "dbo",
                        principalTable: "Estudiantes",
                        principalColumn: "IDEstudiantes",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                schema: "dbo",
                columns: table => new
                {
                    IDCursos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripción = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDProfesores = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.IDCursos);
                    table.ForeignKey(
                        name: "FK_Cursos_Profesores_IDProfesores",
                        column: x => x.IDProfesores,
                        principalSchema: "dbo",
                        principalTable: "Profesores",
                        principalColumn: "IDProfesores",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profesoresnotas",
                schema: "dbo",
                columns: table => new
                {
                    NotasIDNota = table.Column<int>(type: "int", nullable: false),
                    ProfesoresIDProfesores = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesoresnotas", x => new { x.NotasIDNota, x.ProfesoresIDProfesores });
                    table.ForeignKey(
                        name: "FK_Profesoresnotas_notas_NotasIDNota",
                        column: x => x.NotasIDNota,
                        principalSchema: "dbo",
                        principalTable: "notas",
                        principalColumn: "IDNota",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profesoresnotas_Profesores_ProfesoresIDProfesores",
                        column: x => x.ProfesoresIDProfesores,
                        principalSchema: "dbo",
                        principalTable: "Profesores",
                        principalColumn: "IDProfesores",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                schema: "dbo",
                columns: table => new
                {
                    ID_inscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Inscripcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDEstudiantes = table.Column<int>(type: "int", nullable: false),
                    ID_cursos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.ID_inscripcion);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Cursos_ID_cursos",
                        column: x => x.ID_cursos,
                        principalSchema: "dbo",
                        principalTable: "Cursos",
                        principalColumn: "IDCursos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Estudiantes_IDEstudiantes",
                        column: x => x.IDEstudiantes,
                        principalSchema: "dbo",
                        principalTable: "Estudiantes",
                        principalColumn: "IDEstudiantes",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_IDProfesores",
                schema: "dbo",
                table: "Cursos",
                column: "IDProfesores");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_ID_cursos",
                schema: "dbo",
                table: "Inscripciones",
                column: "ID_cursos");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_IDEstudiantes",
                schema: "dbo",
                table: "Inscripciones",
                column: "IDEstudiantes");

            migrationBuilder.CreateIndex(
                name: "IX_notas_IDEstudiantes",
                schema: "dbo",
                table: "notas",
                column: "IDEstudiantes");

            migrationBuilder.CreateIndex(
                name: "IX_Profesoresnotas_ProfesoresIDProfesores",
                schema: "dbo",
                table: "Profesoresnotas",
                column: "ProfesoresIDProfesores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscripciones",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Profesoresnotas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cursos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "notas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Profesores",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Estudiantes",
                schema: "dbo");
        }
    }
}
