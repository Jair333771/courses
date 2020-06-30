using Core.Interfaces;
using Core.Models;
using DAL.Context;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Logic
{
    public class AssignmentBLL : AppBLL
    {
        protected IRepository<Assignment> repo;
        protected IRepository<Person> repoPerson;
        protected IRepository<Course> repoCourse;

        public AssignmentBLL(ApiDbContext context)
        {
            repo = new AppRepository<Assignment>(context);
            repoPerson = new AppRepository<Person>(context);
            repoCourse = new AppRepository<Course>(context);
        }

        public ResponseModel Add(AssignmentModel model)
        {
            var person = repoPerson.GetById(model.Id);
            var course = repoCourse.GetById(model.Id);
            int state;

            if (person != null && course != null)
            {
                state = repo.Add(model);
            }
            else
            {
                state = 5;
            }
            
            SetObjectResponse(model, state);
            return response;
        }

        public ResponseModel Update(AssignmentModel model)
        {
            var state = repo.Update(model);
            SetObjectResponse(model, state);
            return response;
        }
    }
}
