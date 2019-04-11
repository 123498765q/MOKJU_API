using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MOKJU_API.Models
{
    public class Payment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ReceiverAccount")]
        public string ReceiverAccount { get; set; }

        [BsonElement("SenderAccount")]
        public string SenderAccount { get; set; }

        [BsonElement("Bill")]
        public decimal Bill { get; set; }

        [BsonElement("ProductName")]
        public string ProductName { get; set; }
    }
}
