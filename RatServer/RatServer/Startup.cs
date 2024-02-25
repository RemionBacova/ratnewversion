using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Extensions.Http;
using RatServer.Core.Caching;
using RatServer.Core.Extensions;
using RatServer.Core.Middleware;
using RatServer.Core.Models;
using RatServer.Core.Registrations;
using RatServer.DataLayer;
using RatServer.DataLayer.Interfaces.Client;
using RatServer.DataLayer.Models.Client;
using RatServer.DataLayer.Repositories.Client;
using RatServer.Global.Constants;
using RatServer.Interfaces;
using RatServer.Interfaces.Client;
using RatServer.Models.Domain;
using RatServer.Models.ViewModel.Client;
using RatServer.Services;
using RatServer.Services.Client;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;

namespace RatServer
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "RATPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static string DefaultCorsPolicyName => _defaultCorsPolicyName;

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddAutoMapper(typeof(Startup).Assembly);
            _ = services.AddHttpContextAccessor();
            _ = services.AddResponseCaching();
            _ = services.AddCors(o => o.AddPolicy(DefaultCorsPolicyName, builder =>
            {
                _ = builder.WithOrigins(
                        Configuration.GetValue<string>("CorsOrigins")
                        .Split(",", StringSplitOptions.RemoveEmptyEntries)
                        .Select(o => o.RemovePostFix("/"))
                        .ToArray()
                    ).AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("Token-Expired");
            }));

            Polly.Retry.AsyncRetryPolicy<HttpResponseMessage> retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .RetryAsync(3);

            Polly.CircuitBreaker.AsyncCircuitBreakerPolicy<HttpResponseMessage> circuitBreakerPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(60));

            IAsyncPolicy<HttpResponseMessage> noOp = Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>();



            services.AddSwagger(Configuration);
            _ = services.AddSwaggerGen(c => { c.EnableAnnotations(); });

            _ = services.AddHealthChecks()
                .AddMongoDb(Configuration.GetConnectionString(GetConString("MongoConnectionString")));
            if (Configuration.GetSection("Misc:enableAPIGZipCompression")?.Value?.ToLower() == "true")
            {
                _ = services.Configure<GzipCompressionProviderOptions>(options =>
                   options.Level = CompressionLevel.Optimal);
                _ = services.AddResponseCompression(options =>
                {
                    options.EnableForHttps = true;
                    options.Providers.Add<GzipCompressionProvider>();
                });
            }

            _ = services.AddMemoryCache();
            _ = services.AddTokenAuthentication(Configuration);
            _ = services.AddSingleton<DataContext>();

            _ = services.AddSingleton<ICacheService, CacheService>();


            _ = services.AddSingleton<IClientRepository, ClientRepository>();
            _ = services.AddSingleton<IClientValuesRepository, ClientValuesRepository>();
            _ = services.AddSingleton<IClientService, ClientService>();
            _ = services.AddSingleton<IFileService, FileService>();

            _ = services.AddAutoMapper(config =>
            {
                _ = config.CreateMap<ClientVM, Client>();
                _ = config.CreateMap<Client, ClientVM>();
                _ = config.CreateMap<ClientValues, ClientValuesVM>();
                _ = config.CreateMap<ClientValuesVM, ClientValues>();


            }, AppDomain.CurrentDomain.GetAssemblies());


            _ = services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
            });

            _ = services.Configure<Setting>(options =>
            {
                options.ConnectionString = GetConString("MongoConnectionString");
                options.Database = Configuration.GetSection("Mongo:Database").Value;
            });

            _ = services.Configure<ApiKeySettings>(options =>
            {
                options.SecretKey = Configuration.GetSection("Authentication:ClientSecret").Value;
            });
            _ = services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            _ = services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _ = app.UseCors(DefaultCorsPolicyName);
            if (Configuration.GetSection("Misc:enableAPIGZipCompression")?.Value?.ToLower() == "true")
            {
                _ = app.UseResponseCompression();
            }
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }
            _ = app.UseHsts();
            _ = app.UseHttpsRedirection();
            _ = app.UseApiResponseExtension(new ApiResponseOptions { ApiVersion = "2.0" });
            _ = app.UseCustomExceptionExtension();
            _ = app.UseRouting();
            _ = app.UseResponseCaching();
            _ = app.UseAuthentication();
            _ = app.UseAuthorization();
            _ = app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();
                _ = endpoints.MapHealthChecks("/health", new HealthCheckOptions
                {
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                });
            });
            string envName = env.EnvironmentName.ToLower();
            if (envName != Constants.ENV_PROD.ToLower() && envName != Constants.ENV_STAGE.ToLower())
            {
                _ = app.UseSwagger();
                _ = app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reward System Base API");
                    c.DocExpansion(DocExpansion.None);
                });
            }
        }

        private string GetConString(string key)
        {
            return key == "MongoConnectionString"
                ? Configuration.GetSection("Mongo:ConnectionString").Value
                : Configuration.GetSection("Mongo:ConnectionString").Value;
        }
    }
}
