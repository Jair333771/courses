using Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Assignment
    {
        [Key]   
        public int Id { get; set; }

        [Required(ErrorMessage = "El userid es requerido")]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "El curso es requerido")]
        public int CourseId { get; set; }

        [NotMapped]
        public virtual ICollection<Person> Person { get; set; }

        [NotMapped]
        public virtual ICollection<Course> Course { get; set; }

        public static implicit operator Assignment(AssignmentModel obj)
        {
            return new Assignment
            {
                Id = obj.Id,
                PersonId = obj.PersonId,
                CourseId = obj.CourseId
            };
        }

        public static implicit operator AssignmentModel(Assignment obj)
        {
            return new AssignmentModel
            {
                Id = obj.Id,
                PersonId = obj.PersonId,
                CourseId = obj.CourseId
            };
        }
    }
}
