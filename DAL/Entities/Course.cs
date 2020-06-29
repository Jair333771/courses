using Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("Courses")]
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La modalidad es requerido")]
        public string Modality { get; set; }

        [Required(ErrorMessage = "La duración es requerido")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "El tipo es requerido")]
        public string Type { get; set; }

        [Required(ErrorMessage = "La categoría es requerido")]
        public string Category { get; set; }

        [Required(ErrorMessage = "La carrera es requerido")]
        public string Career { get; set; }

        [NotMapped]
        public virtual ICollection<Assignment> Assignments { get; set; }

        public static implicit operator Course(CourseModel.CourseUpdateModel obj)
        {
            return new Course
            {
                Id = obj.Id,
                Name = obj.Name,
                Modality = obj.Modality,
                Duration = obj.Duration,
                Type = obj.Type,
                Category = obj.Category,
                Career = obj.Career
            };
        }

        public static implicit operator CourseModel.CourseUpdateModel(Course obj)
        {
            return new CourseModel.CourseUpdateModel
            {
                Id = obj.Id,
                Name = obj.Name,
                Modality = obj.Modality,
                Duration = obj.Duration,
                Type = obj.Type,
                Category = obj.Category,
                Career = obj.Career
            };
        }
    }
}
