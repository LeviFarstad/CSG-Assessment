using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CSGAPI.Models
{
    public class ATMBalance
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string ATMID { get; set; }
        public decimal Balance { get; set; }
    }
}