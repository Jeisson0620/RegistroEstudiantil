namespace RegistroEstudiantil.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Profesores", Schema = "dbo")]
    public class Profesores
    {
        [Key]
        public int IDProfesores { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public virtual ICollection<Cursos> Cursos { get; set; }
        public virtual ICollection<notas> Notas { get; set; }
    }
}
