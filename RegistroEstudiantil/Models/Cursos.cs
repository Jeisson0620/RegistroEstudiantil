namespace RegistroEstudiantil.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Cursos", Schema = "dbo")]
    public class Cursos
    {
        [Key]
        public int IDCursos { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }

        [ForeignKey("Profesores")]
        public int IDProfesores { get; set; }
        
       
         public virtual Profesores Profesores { get; set; }
        public virtual ICollection<Inscripciones> Inscripciones { get; set; }

    }
}
