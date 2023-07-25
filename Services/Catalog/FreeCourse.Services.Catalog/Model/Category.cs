using MongoDB.Bson.Serialization.Attributes;

namespace FreeCourse.Services.Catalog.Model
{
    internal class Category
    {
        // BsonId attribute ile ilgili alanın MongoDb de Id olarak algılanması sağlanır. 
        // BsonRepresentation attribute ile ilgili alanın tipi belirlenir
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
