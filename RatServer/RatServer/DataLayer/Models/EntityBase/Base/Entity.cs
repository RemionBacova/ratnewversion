using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace RatServer.DataLayer.Models.EntityBase.Base
{
    [BsonIgnoreExtraElements(Inherited = true)]

    public class Entity<TKey> : IEntity
      where TKey : IEquatable<TKey>
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonElement("createdOn")]
        public DateTime createdOn { get; set; }

        [BsonRepresentation(BsonType.String)]
        [BsonElement("userId")]
        public string userId { get; set; }
    }

    public class Entity : Entity<string>
    {
        public Entity()
        {
            id = ObjectId.GenerateNewId().ToString();
            createdOn = DateTime.UtcNow;
        }

    }
    public interface IEntity<T>
    {
        T id { get; set; }
    }

    public interface IEntity : IEntity<string>
    {

    }


}
