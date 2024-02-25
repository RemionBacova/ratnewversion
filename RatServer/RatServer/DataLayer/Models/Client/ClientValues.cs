using MongoDB.Bson.Serialization.Attributes;

namespace RatServer.DataLayer.Models.Client
{
    public class ClientValues : EntityBase.Base.Entity
    {
        [BsonElement("clientId")]
        public string clientId { get; set; }

        [BsonElement("data")]
        public string data { get; set; }

        [BsonElement("value")]
        public string value { get; set; }
    }
}
