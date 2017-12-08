using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApplicationName.Classes
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}
