using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CSGAPI.Models
{
    public class UserAccounts
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Decimal Balance { get; set; }
        public Decimal WithdrawalLimit { get; set; }
    }
}