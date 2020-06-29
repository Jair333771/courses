using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IUserRepository<T> where T : class
    {
        public List<T> GetByAgeRange(DateTime startDate, DateTime endDate);
    }
}
