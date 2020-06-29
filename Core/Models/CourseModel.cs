using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [NotMapped]
    public class CourseModel
    {
        public class CourseBaseModel
        {
            [Key]
            public int Id { get; set; }

            public virtual string Name { get; set; }

            public virtual string Modality { get; set; }

            public virtual int Duration { get; set; }

            public virtual string Type { get; set; }

            public virtual string Category { get; set; }

            public virtual string Career { get; set; }
        }

        public class CourseUpdateModel : CourseBaseModel
        {
            [Required(ErrorMessage = "El nombre es requerido")]
            public override string Name { get; set; }

            [Required(ErrorMessage = "La modalidad es requerido")]
            public override string Modality { get; set; }

            [Required(ErrorMessage = "La duración es requerido")]
            public override int Duration { get; set; }

            [Required(ErrorMessage = "El tipo es requerido")]
            public override string Type { get; set; }

            [Required(ErrorMessage = "La categoría es requerido")]
            public override string Category { get; set; }

            [Required(ErrorMessage = "La carrera es requerido")]
            public override string Career { get; set; }
        }
    }
}
