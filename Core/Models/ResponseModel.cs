using System;
using System.Collections.Generic;
using System.Net;

namespace Core.Models
{
    public class ResponseModel
    {
        public Exception Exception { get; set; }
        public MessageModel Message { get; set; }
        public object Data { get; set; }
    }

    public class MessageModel
    {
        public int Id { get; set; }
        public HttpStatusCode Status { get; set; }
        public string Description { get; set; }
    }

    public class MessageListModel
    {
        public List<MessageModel> ErrorList { get; set; } = new List<MessageModel> {
             new MessageModel {
                Id = 1,
                Description = "Consulta exitosa",
                Status = HttpStatusCode.OK
            },
            new MessageModel {
                Id = 2,
                Description = "No se han encontrado resultados",
                Status = HttpStatusCode.NotFound
            },
            new MessageModel {
                Id = 3,
                Description = "El dato que ingreso no existe en la bd",
                Status = HttpStatusCode.BadRequest
            },
            new MessageModel {
                Id = 4,
                Description = "Ha ocurrido un error inesperado mientras se procesaba tu solicitud",
                Status = HttpStatusCode.InternalServerError
            }
        };
    }
}
