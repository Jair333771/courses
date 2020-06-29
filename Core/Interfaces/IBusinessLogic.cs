using Core.Models;

namespace Core.Interfaces
{
    public interface IBussinessLogic
    {
        public ResponseModel GetAll();
        public ResponseModel GetById(int id);
    }
}
