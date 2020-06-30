using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [NotMapped]
    public class PersonModel
    {
        public class PersonBaseModel
        {
            [Key]
            public int Id { get; set; }

            public virtual string FullName { get; set; }

            public virtual string Document { get; set; }

            public virtual string Email { get; set; }

            public virtual DateTime BornDate { get; set; }

            public virtual string Role { get; set; }

            public virtual string Gender { get; set; }
        }

        public class PersonUpdateModel : PersonBaseModel
        {
            [Required(ErrorMessage = "El nombre completo es requerido")]
            public override string FullName { get; set; }

            [Required(ErrorMessage = "El Document es requerido")]
            public override string Document { get; set; }

            [Required(ErrorMessage = "El correo es requerido")]
            public override string Email { get; set; }

            [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public override DateTime BornDate { get; set; }

            [Required(ErrorMessage = "El rol es requerido")]
            public override string Role { get; set; }

            [Required(ErrorMessage = "El rol es requerido")]
            public override string Gender { get; set; }
        }
    }
}
