using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]//Benzersiz bir id oluşturur
        public string CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}