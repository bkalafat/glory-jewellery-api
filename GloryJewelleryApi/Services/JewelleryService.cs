using System.Collections.Generic;
using GloryJewelleryApi.Models;
using MongoDB.Driver;

namespace GloryJewelleryApi.Services
{
    public class JewelleryService : IJewelleryService
    {
        private readonly IMongoCollection<Jewellery> _jewellery;

        public JewelleryService(IJewelleryDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _jewellery = database.GetCollection<Jewellery>(settings.JewelleryCollectionName);
        }

        public List<Jewellery> Get() =>
            _jewellery.Find(jewellery => true).ToList();

        public Jewellery Get(string id) =>
            _jewellery.Find<Jewellery>(jewellery => jewellery.Id == id).FirstOrDefault();

        public Jewellery Create(Jewellery jewellery)
        {
            _jewellery.InsertOne(jewellery);
            return jewellery;
        }

        public void Update(string id, Jewellery newJewellery) =>
            _jewellery.ReplaceOne(book => book.Id == id, newJewellery);


        public void Remove(string id) => 
            _jewellery.DeleteOne(book => book.Id == id);
    }
}
