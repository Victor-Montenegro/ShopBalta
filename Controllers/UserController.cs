using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Filters;
using Shop.Language;
using Shop.Models;
using Shop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("users")]
    public class UserController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get([FromServices] DataContext context)
        {
            try
            {
                List<User> users = await context.User.AsNoTracking().ToListAsync();

                if (users == null)
                    return BadRequest(new { message = ApiMsg.ISE0015 });

                return Ok(users);
            }
            catch
            {
                return BadRequest(new { message = ApiMsg.EXE0013 });
            }
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<ActionResult<User>> GetId(int id,
            [FromServices] DataContext context)
        {
            try
            {
                User user = await context.User.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

                if (user == null)
                    return BadRequest(new { message = ApiMsg.ISE0016 });

                return Ok(user);
            }
            catch 
            {
                return BadRequest(new { message = ApiMsg.EXE0014 });
            }
        }

        [Route("")]
        [HttpPost]
        [AllowAnonymous]
        [ValidationErrors]
        public async Task<ActionResult<User>> Post([FromBody] User model,
            [FromServices]DataContext context)
        {
            try
            {
                context.User.Add(model);
                await context.SaveChangesAsync();

                return Ok(new { message = ApiMsg.ISE0017, model = model });
            }
            catch
            {
                return BadRequest(new { message = ApiMsg.EXE0015 });
            }
        }

        [Route("Login")]
        [HttpPost]
        [ValidationErrors]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model,
            [FromServices]DataContext context)
        {
            try
            {
                User user = await context.User.Where(x => x.Username == model.Username && x.Password == model.Password).AsNoTracking().SingleOrDefaultAsync();

                if (user == null)
                    return NotFound(new { message = ApiMsg.ISE0018 });

                var token = TokenService.GenereteToken(user);

                return Ok(new { message = ApiMsg.ISE0019, user = new { user.Username,user.Role }, token = token});
            }
            catch (Exception)
            {
                return BadRequest(new { message = ApiMsg.EXE0018 });
            }
        }
    }
}
