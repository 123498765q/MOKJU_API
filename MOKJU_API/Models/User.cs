using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOKJU_API.Services;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MOKJU_API.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Surname")]
        public string Surname { get; set; }

        [BsonElement("AccountNumber")]
        public string AccountNumber { get; set; }

        [BsonElement("AccountBalance")]
        public decimal AccountBalance { get; set; }
    }
}
