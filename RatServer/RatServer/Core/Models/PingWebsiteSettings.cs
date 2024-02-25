using System;

namespace RatServer.Core.Models
{
    public class PingWebsiteSettings
    {
        public Uri Url { get; set; }
        public int TimeIntervalInMinutes { get; set; }
    }
}
