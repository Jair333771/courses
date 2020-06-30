using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Logic
{
    public class AppBLL
    {
        protected ResponseModel response;
        protected MessageModel message;
        protected MessageListModel messageList;

        public void SetObjectResponse<T>(T obj, int state = 0)
        {
            response = new ResponseModel();
            message = new MessageModel();
            messageList = new MessageListModel();

            try
            {
                if (state == 3) 
                {
                    response.Data = obj;
                    message = messageList.ErrorList
                        .Where(x => x.Id == 3)
                        .FirstOrDefault();
                }
                if (obj != null && state == 1)
                {
                    response.Data = obj;
                    message = messageList.ErrorList
                        .Where(x => x.Id == 1)
                        .FirstOrDefault();
                }
                else
                {
                    message = messageList.ErrorList
                        .Where(x => x.Id == 2)
                        .FirstOrDefault();
                }
                response.Message = message;
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = messageList.ErrorList.Where(x => x.Id == 4)
                    .FirstOrDefault();
            }
        }

        public void SetListResponse<T>(List<T> list)
        {
            response = new ResponseModel();
            message = new MessageModel();
            messageList = new MessageListModel();

            try
            {
                if (list.Count > 0)
                {
                    response.Data = list;
                    message = messageList.ErrorList
                        .Where(x => x.Id == 1)
                        .FirstOrDefault();
                }
                else
                {
                    message = messageList.ErrorList
                        .Where(x => x.Id == 2)
                        .FirstOrDefault();
                }
                response.Message = message;
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Message = messageList.ErrorList.Where(x => x.Id == 4)
                    .FirstOrDefault();
            }
        }
    }
}
