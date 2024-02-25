using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace RatServer.Core.Filters
{
    public class ValidateModelStateFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ModelStateDictionary state = context.ModelState;
            context.HttpContext.Features.Set<ModelStateDictionary>(state);
            _ = await next();
        }
    }
}
