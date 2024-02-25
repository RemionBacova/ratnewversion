using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RatServer.Core.Models;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RatServer.Core.HealthCheck
{
    internal class PingWebsiteBackgroundService : BackgroundService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<PingWebsiteBackgroundService> _logger;
        private readonly IOptions<PingWebsiteSettings> _configuration;

        public PingWebsiteBackgroundService(
            IHttpClientFactory httpClientFactory,
            ILogger<PingWebsiteBackgroundService> logger,
            IOptions<PingWebsiteSettings> configuration)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"{nameof(PingWebsiteBackgroundService)} running at '{DateTime.Now}', pinging '{_configuration.Value.Url}'");
                try
                {
                    using HttpClient client = _httpClientFactory.CreateClient(nameof(PingWebsiteBackgroundService));
                    HttpResponseMessage response = await client.GetAsync(_configuration.Value.Url, stoppingToken);
                    _logger.LogInformation($"Is {_configuration.Value.Url.Authority} responding: {response.IsSuccessStatusCode}");
                }
                catch (System.Exception ex)
                {
                    _logger.LogError(ex, "Error during ping");
                }
                await Task.Delay(TimeSpan.FromMinutes(_configuration.Value.TimeIntervalInMinutes), stoppingToken);
            }
        }
    }
}
