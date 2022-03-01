using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Filters;
using Shop.Language;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get([FromServices]DataContext context)
        {
            try
            {
                var products = await context.Product.Include(p => p.Category).AsNoTracking().ToListAsync();

                return Ok(products);
            }
            catch (Exception)
            {
                return BadRequest(new { message = ApiMsg.EXE0006 });
            }
        }
        [Route("{id:int}")]
        [HttpGet]
        public async Task<ActionResult<Product>> GetId(int id,
            [FromServices]DataContext context)
        {
            try
            {
                var product = await context.Product.Include(p => p.Category).AsNoTracking().FirstOrDefaultAsync();

                if (product == null)
                    return BadRequest(new { message = ApiMsg.ISE0009 });

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest(new { message = ApiMsg.EXE0007 });
            }
        }

        [Route("categories/{id:int}")]
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProductsByCategoryId(int id,
            [FromServices]DataContext context)
        {
            try
            {
                var products = await context.Product.Include(p => p.Category).Where(p => p.CategoryId == id).AsNoTracking().ToListAsync();

                if(products == null)
                    return BadRequest(new { message = ApiMsg.ISE0010 });

                return Ok(products);
            }
            catch (Exception)
            {
                return BadRequest(new { message = ApiMsg.EXE0008 });
            }
        }


        [Route("")]
        [HttpPost]
        [ValidationErrors]
        public async Task<ActionResult<Product>> Post([FromBody]Product model,
            [FromServices]DataContext context)
        {
            try
            {
                context.Product.Add(model);
                await context.SaveChangesAsync();

                return Ok(new { message = ApiMsg.ISE0011, model = model });
            }
            catch (Exception)
            {
                return BadRequest(new { message = ApiMsg.EXE0009 });
            }
        }


        [Route("{id:int}")]
        [HttpPut]
        [ValidationErrors]
        public async Task<ActionResult<Product>> Put(int id,
            [FromBody]Product model,
            [FromServices]DataContext context)
        {
            if (model.Id.Equals(id))
                return BadRequest(new { message = ApiMsg.ISE0009 });

            try
            {
                context.Entry<Product>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return Ok(new { message = ApiMsg.ISE0012, model = model });
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = ApiMsg.EXE0010 });
            }
            catch (Exception)
            {
                return BadRequest(new { message = ApiMsg.EXE0011});
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public async Task<ActionResult<Product>> Delete(int id,
            [FromServices]DataContext context)
        {
            try
            {
                var product = await context.Product.FirstOrDefaultAsync(p => p.Id == id);

                if (product == null)
                    return BadRequest();

                context.Product.Remove(product);
                await context.SaveChangesAsync();

                return Ok(new { message = ApiMsg.ISE0013, model = product });
            }
            catch (Exception)
            {
                return BadRequest(new { message = ApiMsg.EXE0012 });
            }
        }
    }
}
