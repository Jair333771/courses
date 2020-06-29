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
    public class PersonController : ControllerBase
    {
        protected PersonBLL logicBll;

        public PersonController(ApiDbContext context)
        {
            logicBll = new PersonBLL(context);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = logicBll.GetAll();
            return StatusCode((int)response.Message.Status, response);
        }

        [Route("getbyagerange")]
        [HttpGet]
        public IActionResult GetByAgeRange()
        {
            var response = logicBll.GetByAgeRange();
            return StatusCode((int)response.Message.Status, response);
        }

        [Route("getbygender")]
        [HttpGet]
        public IActionResult GetByGender()
        {
            var response = logicBll.GetByGender();
            return StatusCode((int)response.Message.Status, response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id = 0)
        {
            var response = logicBll.GetById(id);
            return StatusCode((int)response.Message.Status, response);
        }

        [HttpPost]
        public IActionResult Add([FromBody] PersonModel.PersonUpdateModel model)
        {
            var response = logicBll.Add(model);
            return StatusCode((int)response.Message.Status, response);
        }

        [HttpPut]
        public IActionResult Update([FromBody] PersonModel.PersonUpdateModel model)
        {
            var response = logicBll.Update(model);
            return StatusCode((int)response.Message.Status, response);
        }
    }
}