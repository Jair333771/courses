using BLL.Logic;
using Core.Models;
using DAL.Context;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DataContract]
    public class AssignmentController : ControllerBase
    {
        protected AssignmentBLL logicBll;

        public AssignmentController(ApiDbContext context)
        {
            logicBll = new AssignmentBLL(context);
        }

        [HttpPost]
        public IActionResult Add([FromBody] AssignmentModel model)
        {
            var response = logicBll.Add(model);
            return StatusCode((int)response.Message.Status, response);
        }

        [HttpPut]
        public IActionResult Update([FromBody] AssignmentModel model)
        {
            var response = logicBll.Update(model);
            return StatusCode((int)response.Message.Status, response);
        }
    }
}