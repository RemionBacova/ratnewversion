using System.Collections.Generic;

namespace RatServer.Core.Models
{
    public class ModelValidationError
    {
        public string title { get; set; }
        public int status { get; set; }
        public Dictionary<string, List<string>> errors { get; set; }
    }
}
