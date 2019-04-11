using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MOKJU_API.Models;
using Microsoft.Extensions.Configuration;

namespace MOKJU_API.Services
{
    public class PaymentService
    {
        private readonly IMongoCollection<Payment> _payment;

        public PaymentService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("BookstoreDb"));
            var database = client.GetDatabase("Database");
            _payment = database.GetCollection<Payment>("Payment");
        }

        public List<Payment> Get()
        {
            return _payment.Find(payment => true).ToList();
        }

        public Payment Get(string id)
        {
            return _payment.Find<Payment>(payment => payment.ReceiverAccount == id).FirstOrDefault();
        }

        public Payment Create(Payment payment)
        {
            _payment.InsertOne(payment);
            return payment;
        }

        public void Update(string id, Payment paymentIn)
        {
            _payment.ReplaceOne(payment => payment.Id == id, paymentIn);
        }

        public void Remove(Payment paymentIn)
        {
            _payment.DeleteOne(payment => payment.Id == paymentIn.Id);
        }

        public void Remove(string id)
        {
            _payment.DeleteOne(payment => payment.Id == id);
        }

    }
}
