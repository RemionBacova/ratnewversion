using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RatServer.DataLayer.Models.EntityBase.Base;

namespace RatServer.DataLayer.Models.EntityBase
{
    public class EntityBase : Entity
    {
        [BsonRepresentation(BsonType.String)]
        [BsonElement("nomination")]
        public string nomination { get; set; }
    }
}
