using Microsoft.AspNetCore.Http;
using RatServer.Core.Exception;
using System;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace RatServer.Core.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JsonSerializerOptions _jsonSettings;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));

            _jsonSettings = new JsonSerializerOptions()
            {
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (RulesException re)
            {
                if (context.Response.HasStarted)
                {
                    throw;
                }

                string json = JsonSerializer.Serialize(re.Errors.FirstOrDefault(), _jsonSettings);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(json);
            }
            catch (CustomException cm)
            {
                if (context.Response.HasStarted)
                {
                    throw;
                }
                context.Response.ContentType = "application/json";
                string json = JsonSerializer.Serialize(cm.CustomError, _jsonSettings);
                _ = int.TryParse(cm?.CustomError?.code, out int httpStatusCode);
                context.Response.StatusCode = httpStatusCode == 0 ? (int)HttpStatusCode.UnprocessableEntity : httpStatusCode;
                await context.Response.WriteAsync(json);
            }
        }
    }
}
