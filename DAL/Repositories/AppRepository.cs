using Core.Interfaces;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class AppRepository<T> : IRepository<T> where T : class
    {
        protected ApiDbContext db;
        protected readonly DbSet<T> table;

        public AppRepository(ApiDbContext db)
        {
            this.db = db;
            table = this.db.Set<T>();
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public int Add(T obj)
        {
            table.Add(obj);
            return db.SaveChanges();
        }

        public int Update(T obj)
        {
            table.Update(obj);
            return db.SaveChanges();
        }

        public int Delete(object id)
        {
            T obj = table.Find(id);
            table.Remove(obj);
            return db.SaveChanges();
        }
    }
}
