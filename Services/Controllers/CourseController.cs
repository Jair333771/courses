using System.Runtime.Serialization;
using BLL.Logic;
using Core.Models;
using DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DataContract]
    public class CourseController : ControllerBase
    {
        protected CourseBLL logicBll;

        public CourseController(ApiDbContext context)
        {
            logicBll = new CourseBLL(context);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = logicBll.GetAll();
            return StatusCode((int)response.Message.Status, response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id = 0)
        {
            var response = logicBll.GetById(id);
            return StatusCode((int)response.Message.Status, response);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CourseModel.CourseUpdateModel model)
        {
            var response = logicBll.Add(model);
            return StatusCode((int)response.Message.Status, response);
        }

        [HttpPut]
        public IActionResult Update([FromBody] CourseModel.CourseUpdateModel model)
        {
            var response = logicBll.Update(model);
            return StatusCode((int)response.Message.Status, response);
        }
    }
}