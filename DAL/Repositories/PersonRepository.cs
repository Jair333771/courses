using Core.Interfaces;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class PersonRepository : AppRepository<Person>, IRepository<Person>
    {
        public PersonRepository(ApiDbContext db) : base(db)
        {
            this.db = db;
        }

        public Person GetByDocument(string document) {
            var obj = db.Person
                .Where(x => x.Document == document)
                .FirstOrDefault();
            return obj;
        } 

        public List<StoredProcedure.GetByAgeRange_Result> GetByAgeRange()
        {
            var list = db.GetByAgeRange_Result
                .FromSqlRaw("EXEC GetByAgeRange")
                .AsNoTracking()
                .AsEnumerable()
                .ToList();

            return list;
        }

        public List<StoredProcedure.GetByGender_Result> GetByGender()
        {
            var list = db.GetByGender_Result
                .FromSqlRaw("EXEC GetByGender")
                .AsNoTracking()
                .AsEnumerable()
                .ToList();

            return list;
        }
    }
}
