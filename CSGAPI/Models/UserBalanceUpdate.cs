using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CSGAPI.Models
{
    public class UserBalanceUpdate {
        
        public string id { get; set; }
        public string Type { get; set; }
        public Decimal Amount { get; set; }

    }
}