using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FTree.Models
{
    public class TreeNode
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.Document)]
        public FamilyMember FamilyMember { get; set; } = new FamilyMember();

        [BsonRepresentation(BsonType.Array)]
        public IEnumerable<int>? Parents { get; set; }

        [BsonRepresentation(BsonType.Array)]
        public IEnumerable<int>? Children { get; set; } 
    }
}
