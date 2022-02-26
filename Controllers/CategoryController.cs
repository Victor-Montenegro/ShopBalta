using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Filters;
using Shop.Language;
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

        public async Task<ActionResult<Category>> Post(
            [FromBody] Category model,
            [FromServices] DataContext context)
        {
            try
            {
                context.Category.Add(model);
                await context.SaveChangesAsync();

                return Ok(model);
            }
            catch
            {
                return BadRequest(new { Message = ApiMsg.EXE0001});
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [ValidationErrors]
        public async Task<ActionResult<Category>> Put(int id,[FromBody] Category model)
        {
            if (!id.Equals(model.Id))
                return NotFound(new { Message = ApiMsg.ISE0006 });

            return model;
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
