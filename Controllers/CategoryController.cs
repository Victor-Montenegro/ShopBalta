using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Filters;
using Shop.Language;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("Categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get([FromServices]DataContext context)
        {
            try
            {
                var category = await context.Category.AsNoTracking().ToListAsync();

                return Ok(category);
            }
            catch (Exception)
            {
                return BadRequest(new { message = ApiMsg.EXE0005 });
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetById(int id,
            [FromServices]DataContext context)
        {
            try
            {
                var category = await context.Category.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

                if (category == null)
                    return BadRequest(new { message = ApiMsg.ISE0006 });

                return Ok(category);
            }
            catch (Exception)
            {
                return BadRequest(new { message = ApiMsg.ISE0006 });
            }
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
        public async Task<ActionResult<Category>> Put(int id,
            [FromBody] Category model,
            [FromServices]DataContext context)
        {
            if (!id.Equals(model.Id))
                return NotFound(new { Message = ApiMsg.ISE0006 });

            try
            {
                context.Entry<Category>(model).State = EntityState.Modified; 

                await context.SaveChangesAsync();

                return Ok(new { message = ApiMsg.ISE0007, category = model });
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = ApiMsg.EXE0002 });
            }
            catch (Exception)
            {
                return BadRequest(new { message = ApiMsg.EXE0003 });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> Delete(int id,
            [FromServices]DataContext context)
        {
            try
            {
                var category = await context.Category.FirstOrDefaultAsync(c => c.Id == id);

                if (category == null)
                    return BadRequest(new { message = ApiMsg.ISE0006 }) ;

                context.Category.Remove(category);

                await context.SaveChangesAsync();

                return Ok(new { message = ApiMsg.ISE0008, category = category });
            }
            catch (Exception)
            {
                return BadRequest(new { message = ApiMsg.EXE0004 });
            }
        }
    }
}
