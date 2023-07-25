namespace RegistroEstudiantil.Models
    
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Estudiantes", Schema = "dbo")]
    public class Estudiantes
    {
        [Key]
        public int IDEstudiantes { get; set; }
        public string Nombres { get; set; }

        public string Apellidos { get; set; }
        public int Edad { get; set; }

        public virtual ICollection<Inscripciones> Inscripciones { get; set; }
        public virtual ICollection<notas> Notas { get; set; }
    }
}
