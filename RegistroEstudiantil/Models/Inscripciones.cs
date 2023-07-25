namespace RegistroEstudiantil.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Inscripciones", Schema = "dbo")]
    public class Inscripciones
    {
        [Key]
        public int ID_inscripcion { get; set; }
        public DateTime Fecha_Inscripcion { get; set; }

        [ForeignKey("Estudiantes")]
        public int IDEstudiantes { get; set; }
       
        [ForeignKey("Cursos")]
        public int ID_cursos { get; set; }


        public virtual Estudiantes Estudiantes { get; set; }
        public virtual Cursos Cursos { get; set; }

        
    }
}
