using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Assignment> Assignment { get; set; }
        public virtual DbSet<StoredProcedure.GetByAgeRange_Result> GetByAgeRange_Result { get; set; }        
        public virtual DbSet<StoredProcedure.GetByGender_Result> GetByGender_Result { get; set; }        
    }
}
