using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GloryJewelleryApi.Models
{
    public class Jewellery
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int fromPrice { get; set; }
        public int price { get; set; }
        public bool isActive { get; set; }
        public string image { get; set; }
    }

    public class JewelleryDatabaseSettings : IJewelleryDatabaseSettings
    {
        public string JewelleryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IJewelleryDatabaseSettings
    {
        string JewelleryCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

}