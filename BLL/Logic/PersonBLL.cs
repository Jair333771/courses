using Core.Interfaces;
using Core.Models;
using DAL.Context;
using DAL.Repositories;

namespace BLL.Logic
{
    public class PersonBLL : AppBLL, IBussinessLogic
    {
        protected PersonRepository repo;

        public PersonBLL(ApiDbContext context)
        {
            repo = new PersonRepository(context);
        }

        public ResponseModel GetAll()
        {
            var list = repo.GetAll();
            SetListResponse(list);

            return response;
        }

        public ResponseModel GetById(int id)
        {
            var obj = repo.GetById(id);
            var state = obj != null ? 1 : 0;
            SetObjectResponse(obj, state);
            return response;
        }

        public ResponseModel Add(PersonModel.PersonUpdateModel model)
        {
            var person = repo.GetByDocument(model.Document);
            int state;

            if (person == null)
            {
                state = repo.Add(model);
            }
            else 
            {
                state = 1;
            }

            SetObjectResponse(model, state);
            return response;
        }

        public ResponseModel Update(PersonModel.PersonUpdateModel model)
        {
            var state = repo.Update(model);
            SetObjectResponse(model, state);
            return response;
        }

        public ResponseModel GetByAgeRange()
        {
            var list = repo.GetByAgeRange();
            SetListResponse(list);

            return response;
        }

        public ResponseModel GetByGender()
        {
            var list = repo.GetByGender();
            SetListResponse(list);

            return response;
        }
    }
}
