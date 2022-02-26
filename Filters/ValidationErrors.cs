using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Shop.Filters
{
    public class ValidationErrors : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
                context.Result = new BadRequestObjectResult(context.ModelState.Values.SelectMany(sm => sm.Errors).Select(s => s.ErrorMessage));
        }
    }
}
