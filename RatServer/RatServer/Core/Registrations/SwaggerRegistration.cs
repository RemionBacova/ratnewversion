using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace RatServer.Core.Registrations
{
    public static class SwaggerRegistration
    {
        public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            _ = services.AddSwaggerGen(swaggerOptions =>
            {
                swaggerOptions.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = configuration.GetValue<string>("Swagger:Title"),
                    Version = configuration.GetValue<string>("Swagger:Version"),
                    Description = configuration.GetValue<string>("Swagger:Description"),
                    Contact = new OpenApiContact
                    {
                        Name = configuration.GetValue<string>("Swagger:Contact_Name"),
                        Url = new Uri(configuration.GetValue<string>("Swagger:URI")),
                    }
                });

                swaggerOptions.OrderActionsBy(x => x.RelativePath);

                swaggerOptions.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                });

                swaggerOptions.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                     {
                        new OpenApiSecurityScheme
                        {
                            Name = "Bearer",
                            Type = SecuritySchemeType.ApiKey,
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                               Id= "Bearer",
                            },
                        },
                        Array.Empty<string>()
                     }
                });
            });
        }
    }
}
