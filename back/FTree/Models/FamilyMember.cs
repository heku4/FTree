using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FTree.Models
{
    public class FamilyMember
    {
        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.String)]
        public string Description { get; set; } = string.Empty;
    }
}
