using CSGAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CSGAPI.Services
{
    public class ATMBalanceService
    {
        private readonly IMongoCollection<ATMBalance> _ATMBalance;

        public ATMBalanceService(IATMBalanceDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _ATMBalance = database.GetCollection<ATMBalance>(settings.ATMBalanceCollectionName);
        }

        public List<ATMBalance> Get() =>
            _ATMBalance.Find(ATMBalance => true).ToList();

        public ATMBalance Get(string id) =>
            _ATMBalance.Find<ATMBalance>(ATMBalance => ATMBalance.Id == id).FirstOrDefault();

        public ATMBalance Create(ATMBalance ATMBalance)
        {
            _ATMBalance.InsertOne(ATMBalance);
            return ATMBalance;
        }

        public void Update(string id, ATMBalance ATMBalanceIn) =>
            _ATMBalance.ReplaceOne(ATMBalance => ATMBalance.Id == id, ATMBalanceIn);

        public void Remove(ATMBalance ATMBalanceIn) =>
            _ATMBalance.DeleteOne(ATMBalance => ATMBalance.Id == ATMBalanceIn.Id);

        public void Remove(string id) => 
            _ATMBalance.DeleteOne(ATMBalance => ATMBalance.Id == id);
    }
}