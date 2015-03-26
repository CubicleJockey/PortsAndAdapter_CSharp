using System;
using MongoDB.Bson.Serialization.Attributes;

namespace PortsAndAdapter.StorageEngine.Entities
{
    public interface IMongoEntity
    {
        [BsonId]
        Guid Id { get; }
    }

    public abstract class MongoEntity : IMongoEntity
    {
        public Guid Id { get; protected set; }
    }
}
