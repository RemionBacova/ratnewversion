using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RatServer.Core.Extensions;
using RatServer.Core.Models;
using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RatServer.Core.Middleware
{
    public class ApiResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly ApiResponseOptions _options;
        private readonly ILogger<ApiResponseMiddleware> _logger;
        public ApiResponseMiddleware(RequestDelegate next, ApiResponseOptions options, ILogger<ApiResponseMiddleware> logger,
                IConfiguration configuration)
        {
            _next = next;
            _options = options;
            _logger = logger;
            _configuration = configuration;
        }

        private string GetHeadervalueFromContext(HttpContext context, string key)
        {
            string headerVal = string.Empty;
            if (context.Request.Headers.TryGetValue(key, out Microsoft.Extensions.Primitives.StringValues traceValue))
            {
                headerVal = traceValue;
            }
            return headerVal;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string headerVal = GetHeadervalueFromContext(context, "responseType");
            if (IsSwagger(context) || headerVal == "blob")
            {
                await _next(context);
            }
            else
            {
                Stream originalBodyStream = context.Response.Body;
                string bodyAsText = "";
                ApiError apiError = null;
                ModelValidationError modelError = null;
                using MemoryStream bodyStream = new();
                try
                {

                    context.Response.Body = bodyStream;

                    await _next.Invoke(context);
                    context.Response.Body = originalBodyStream;
                    string response = context.Response.ContentType is not ("application/csv" or "application/xls") ? await FormatResponse(bodyStream)
                        : await FormatCSVResponse(bodyStream);
                    if (context.Features.Get<ModelStateDictionary>() != null && !context.Features.Get<ModelStateDictionary>().IsValid)
                    {
                        context.Response.StatusCode = context.Response.StatusCode != (int)HttpStatusCode.OK ? (int)HttpStatusCode.BadRequest : context.Response.StatusCode;
                        apiError = new ApiError("Missing or Invalid parameters", "400", context.Features.Get<ModelStateDictionary>().Errors(true));
                    }
                    else if (context.Response.StatusCode != (int)HttpStatusCode.OK)
                    {
                        if (response.ConvertToJson() != null)
                        {
                            modelError = JsonSerializer.Deserialize<ModelValidationError>(response);
                            if (modelError.errors != null)
                            {
                                modelError = JsonSerializer.Deserialize<ModelValidationError>(response);
                                apiError = new ApiError("Missing or Invalid parameters", "400", modelError.errors);
                            }
                            else
                            {
                                apiError = JsonSerializer.Deserialize<ApiError>(response);
                                _ = int.TryParse(apiError.code, out int code);
                                code = code == 0 ? 500 : code; //set default to 500
                                context.Response.StatusCode = code;
                            }
                        }
                    }
                    else
                    {
                        context.Response.Headers.Add("Cache-control", "no-store");
                        context.Response.Headers.Add("Pragma", "no-cache");
                        bodyAsText = response;
                    }
                }
                catch (System.Exception ex)
                {

                    Console.Write("ApiResponseMiddleware Exception = {0}", ex?.Message);
                    _logger.LogError("ApiResponseMiddleware Exception = {0}", ex.Message);

                    if (_configuration["Environment"]?.ToLower() != "prod")
                    {
                        context.Response.Body = originalBodyStream;
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        apiError = new ApiError("ApiResponseMiddleware Exception", "500", new { message = ex.Message });
                    }
                }
                finally
                {
                    await BuildResponse(context, bodyAsText, context.Response.StatusCode, apiError);
                    _logger.Log(LogLevel.Information,
                                $@"Request: {context.Request} Responded with [{context.Response.StatusCode}]");
                }

            }

        }

        private Task BuildResponse(HttpContext context, object body, int code, ApiError apiError)
        {
            if (context.Response.ContentType is "application/csv" or "application/xls")
            {
                return context.Response.WriteAsync(body.ToString(), System.Text.Encoding.GetEncoding("iso-8859-1"));
            }
            string bodyText = !body.ToString().IsValidJson() ? JsonSerializer.Serialize(body, JSONSettings()) : body.ToString();
            dynamic bodyContent = JsonSerializer.Deserialize<dynamic>(bodyText);
            ApiResponse apiResponse = new(GetApiVersion(), code, code.ToString().ToEnum<HttpStatusCode>(false).ToString(), bodyContent, apiError);
            if (context.Response.ContentType != "application/octet-stream")
            {
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync(JsonSerializer.Serialize(apiResponse, JSONSettings()));
            }
            else
            {
                return context.Response.WriteAsync(body.ToString());
            }
        }

        private async Task<string> FormatResponse(Stream bodyStream)
        {
            _ = bodyStream.Seek(0, SeekOrigin.Begin);
            string plainBodyText = await new StreamReader(bodyStream).ReadToEndAsync();
            _ = bodyStream.Seek(0, SeekOrigin.Begin);

            return plainBodyText;
        }

        private async Task<string> FormatCSVResponse(Stream bodyStream)
        {
            _ = bodyStream.Seek(0, SeekOrigin.Begin);
            string plainBodyText = await new StreamReader(bodyStream, System.Text.Encoding.GetEncoding("iso-8859-1")).ReadToEndAsync();
            _ = bodyStream.Seek(0, SeekOrigin.Begin);

            return plainBodyText;
        }

        private string GetApiVersion()
        {
            return string.IsNullOrEmpty(_options.ApiVersion) ? "1.0.0.0" : _options.ApiVersion;
        }

        private JsonSerializerOptions JSONSettings()
        {
            return new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter() },
                WriteIndented = true
            };
        }
        private bool IsSwagger(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments("/swagger");

        }

    }
}
