﻿using Core.Interfaces;
using Core.Models;
using DAL.Context;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.Logic
{
    public class CourseBLL : AppBLL, IBussinessLogic
    {
        protected IRepository<Course> repo;

        public CourseBLL(ApiDbContext context)
        {
            repo = new AppRepository<Course>(context);
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

        public ResponseModel Add(CourseModel.CourseUpdateModel model)
        {
            var course = repo.GetByName(model.Name);
            int state;

            if (course == null)
            {
                state = repo.Add(model);
            }
            else
            {
                state = 3;
            }

            SetObjectResponse(model, state);
            return response;
        }

        public ResponseModel Update(CourseModel.CourseUpdateModel model)
        {
            var state = repo.Update(model);
            SetObjectResponse(model, state);
            return response;
        }
    }
}
