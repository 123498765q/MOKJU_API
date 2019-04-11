using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MOKJU_API.Models;
using Microsoft.Extensions.Configuration;

namespace MOKJU_API.Services
{
    public class ShopService
    {
        private readonly IMongoCollection<Shop> _shop;

        public ShopService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("BookstoreDb"));
            var database = client.GetDatabase("Database");
            _shop = database.GetCollection<Shop>("Shop");
        }

        public List<Shop> Get()
        {
            return _shop.Find(shop => true).ToList();
        }

        public Shop Get(string id)
        {
            return _shop.Find<Shop>(shop => shop.Id == id).FirstOrDefault();
        }

        public Shop Create(Shop shop)
        {
            _shop.InsertOne(shop);
            return shop;
        }

        public void Update(string id, Shop shopIn)
        {
            _shop.ReplaceOne(shop => shop.Id == id, shopIn);
        }

        public void Remove(Shop shopIn)
        {
            _shop.DeleteOne(shop => shop.Id == shopIn.Id);
        }

        public void Remove(string id)
        {
            _shop.DeleteOne(shop => shop.Id == id);
        }
    }
}
