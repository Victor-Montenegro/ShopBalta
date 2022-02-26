using Microsoft.AspNetCore.Mvc;
using Shop.Filters;
using Shop.Models;
using System;

namespace Shop.Controllers
{
    [Route("Categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "Get";
        }

        [HttpGet]
        [Route("{id:int}")]
        public string GetById(int id)
        {
            return "Get" + id.ToString();
        }

        [HttpPost]       
        [Route("")]
        [ValidationErrors]

        public IActionResult Post([FromBody] Category model)
        {
            try
            {
                return Ok(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("")]
        public string Delete()
        {
            return "Delete";
        }

        [HttpPut]
        [Route("")]
        public string Put()
        {
            return "Put";
        }

    }
}
