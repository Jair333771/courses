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

        public AssignmentBLL(ApiDbContext context)
        {
            repo = new AppRepository<Assignment>(context);
        }

        public ResponseModel Add(AssignmentModel model)
        {
            var state = repo.Add(model);
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
