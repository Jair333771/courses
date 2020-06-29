using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("Persons")]
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre completo es requerido")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime BornDate { get; set; }

        [Required(ErrorMessage = "El rol es requerido")]
        public string Role { get; set; }

        [Required(ErrorMessage = "El genero es requerido")]
        public string Gender { get; set; }

        [NotMapped]
        public virtual ICollection<Assignment> Assignments { get; set; }

        public static implicit operator Person(PersonModel.PersonUpdateModel obj)
        {
            return new Person
            {
                Id = obj.Id,
                FullName = obj.FullName,
                Email = obj.Email,
                BornDate = obj.BornDate,
                Role = obj.Role,
                Gender = obj.Gender
            };
        }

        public static implicit operator PersonModel.PersonUpdateModel(Person obj)
        {
            return new PersonModel.PersonUpdateModel
            {
                Id = obj.Id,
                FullName = obj.FullName,
                Email = obj.Email,
                BornDate = obj.BornDate,
                Role = obj.Role,
                Gender = obj.Gender
            };
        }
    }
}
