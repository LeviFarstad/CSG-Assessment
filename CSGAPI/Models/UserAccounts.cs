using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CSGAPI.Models
{
    public class UserAccounts
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }
        public double WithdrawalLimit { get; set; }
    }
}