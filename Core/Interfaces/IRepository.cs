using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public List<T> GetAll();

        public T GetById(int id);

        public T GetByName(string name);

        public int Add(T obj);

        public int Update(T obj);

        public int Delete(object id);
    }
}
