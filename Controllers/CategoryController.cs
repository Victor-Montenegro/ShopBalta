using Microsoft.AspNetCore.Mvc;
using Shop.Filters;
using Shop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("Categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get()
        {
            List<Category> category = new List<Category>();

            return category;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            Category category = new Category();
            return category;
        }

        [HttpPost]
        [Route("")]
        [ValidationErrors]

        public async Task<ActionResult<Category>> Post([FromBody] Category model)
        {
            return Ok(model);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> Put(int id,[FromBody] Category category)
        {
            return category;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> Delete()
        {
            Category category = new Category();
            return category;
        }
    }
}
