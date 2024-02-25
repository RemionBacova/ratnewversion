using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RatServer.Core.Models;
using RatServer.Global.SystemErrors;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace RatServer.Core.Filters
{
    public class ApiKeyAuthorizationFilter : IAuthorizationFilter
    {
        private IOptions<Models.ApiKeySettings> options;
        public ApiKeyAuthorizationFilter(IOptions<Models.ApiKeySettings> options)
        {
            this.options = options;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
            {
                return;
            }
            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out Microsoft.Extensions.Primitives.StringValues values))
            {
                context.Result = new UnauthorizedObjectResult(nameof(CustomSystemErrors.AuthorizationHeaderIsMissing));
                context.HttpContext.Items.Add(HttpStatusCode.ExpectationFailed, new ApiError(nameof(CustomSystemErrors.AuthorizationHeaderIsMissing), ((int)HttpStatusCode.ExpectationFailed).ToString(), CustomSystemErrors.AuthorizationHeaderIsMissing));
                return;
            }

            string authorization = values.FirstOrDefault();
            if (string.IsNullOrWhiteSpace(authorization))
            {

                context.Result = new UnauthorizedObjectResult(nameof(CustomSystemErrors.AuthorizationHeaderIsEmpty));
                context.HttpContext.Items.Add(HttpStatusCode.ExpectationFailed, new ApiError(nameof(CustomSystemErrors.AuthorizationHeaderIsEmpty), ((int)HttpStatusCode.ExpectationFailed).ToString(), CustomSystemErrors.AuthorizationHeaderIsEmpty));
                return;
            }

            if (authorization != options.Value.SecretKey)
            {
                context.Result = new UnauthorizedObjectResult(nameof(CustomSystemErrors.ApiKeyAuthorizationHeaderValueDoesNotMatchBearer));
                context.HttpContext.Items.Add(HttpStatusCode.ExpectationFailed, new ApiError(nameof(CustomSystemErrors.ApiKeyAuthorizationHeaderValueDoesNotMatchBearer), ((int)HttpStatusCode.ExpectationFailed).ToString(), CustomSystemErrors.ApiKeyAuthorizationHeaderValueDoesNotMatchBearer));

            }

        }
    }
}
