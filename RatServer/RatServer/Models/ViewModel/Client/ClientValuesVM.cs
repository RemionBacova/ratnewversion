using MongoDB.Bson.Serialization.Attributes;

namespace RatServer.Models.ViewModel.Client
{
    public class ClientValuesVM
    {
        public string id { get; set; }
        public string clientId { get; set; }

        public string data { get; set; }

        public string value { get; set; }
    }
}
