using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RegistroEstudiantil.Models;

namespace RegistroEstudiantil.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RegistroEstudiantil.Models.Cursos>? Cursos { get; set; }
        public DbSet<RegistroEstudiantil.Models.Estudiantes>? Estudiantes { get; set; }
        public DbSet<RegistroEstudiantil.Models.Inscripciones>? Inscripciones { get; set; }
        public DbSet<RegistroEstudiantil.Models.notas>? notas { get; set; }
        public DbSet<RegistroEstudiantil.Models.Profesores>? Profesores { get; set; }
    }
}