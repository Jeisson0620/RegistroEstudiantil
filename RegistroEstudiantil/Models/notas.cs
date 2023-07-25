namespace RegistroEstudiantil.Models

{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("notas", Schema = "dbo")]
    public class notas
    {
        [Key]
        public int IDNota { get; set; }
        public int nota { get; set; }

        [ForeignKey("Estudiantes")]
        public int IDEstudiantes { get; set; }
       
        [ForeignKey("Profesores")]
        public int IDProfesores { get; set; }

        public virtual ICollection<Profesores> Profesores { get; set; }
        public virtual Estudiantes Estudiantes { get; set; }
    }
}
