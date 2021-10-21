using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CSGAPI.Models
{
    public class UserBalanceUpdateResponse {
        
        public string Status { get; set; }
        public string StatusText { get; set; }
        public Decimal NewBalance { get; set; }
    }
}