using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace ScrumRandomizerServer.Data.Users.Models
{
    [BsonIgnoreExtraElements]
    public class MongoUser : IUser
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; } = Guid.Empty;

        public string Name { get; set; } = string.Empty;
    }
}