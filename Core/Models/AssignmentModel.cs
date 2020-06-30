using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class AssignmentModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El userid es requerido")]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "El curso es requerido")]
        public int CourseId { get; set; }

        [NotMapped]
        public virtual ICollection<PersonModel.PersonUpdateModel> User { get; set; }

        [NotMapped]
        public virtual ICollection<CourseModel.CourseUpdateModel> Course { get; set; }
    }
}
