using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class StoredProcedure
    {
        public class GetByAgeRange_Result
        {
            [Key]
            public int Id { get; set; }
            public string Range { get; set; }
            public int Total { get; set; }
        }

        public class GetByGender_Result
        {
            [Key]
            public int Id { get; set; }
            public string Gender { get; set; }
            public int Total { get; set; }
        }
    }
}
