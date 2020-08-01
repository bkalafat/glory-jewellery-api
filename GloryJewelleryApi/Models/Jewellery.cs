using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GloryJewelleryApi.Models
{
    public class Jewellery
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FromPrice { get; set; }
        public int Price { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
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