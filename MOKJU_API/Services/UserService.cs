using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MOKJU_API.Models;
using Microsoft.Extensions.Configuration;

namespace MOKJU_API.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _user;

        public UserService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("BookstoreDb"));
            var database = client.GetDatabase("Database");
            _user = database.GetCollection<User>("User");
        }

        public List<User> Get()
        {
            return _user.Find(user => true).ToList();
        }

        public User Get(string id)
        {
            return _user.Find<User>(user => user.Id == id).FirstOrDefault();
        }

        public User Create(User user)
        {
            _user.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn)
        {
            _user.ReplaceOne(user => user.Id == id, userIn);
        }

        public void Remove(User userIn)
        {
            _user.DeleteOne(user => user.Id == userIn.Id);
        }

        public void Remove(string id)
        {
            _user.DeleteOne(user => user.Id == id);
        }
    }
}
