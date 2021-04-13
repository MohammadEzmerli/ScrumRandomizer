using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.ComponentModel.DataAnnotations;

namespace ScrumRandomizerServer.Data.Users.Models
{
    [BsonIgnoreExtraElements]
    public class MongoUser : IUser
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; } = Guid.Empty;

        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;
    }
}