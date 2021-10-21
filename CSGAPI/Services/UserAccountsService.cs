using CSGAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CSGAPI.Services
{
    public class UserAccountsService
    {
        private readonly IMongoCollection<UserAccounts> _UserAccounts;

        public UserAccountsService(IUserAccountsDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _UserAccounts = database.GetCollection<UserAccounts>(settings.UserAccountsCollectionName);
        }

        public List<UserAccounts> Get() =>
            _UserAccounts.Find(UserAccounts => true).ToList();

        public UserAccounts Get(string id) =>
            _UserAccounts.Find<UserAccounts>(UserAccounts => UserAccounts.Id == id).FirstOrDefault();

        public UserAccounts Create(UserAccounts UserAccounts)
        {
            _UserAccounts.InsertOne(UserAccounts);
            return UserAccounts;
        }

        public void Update(string id, UserAccounts UserAccountsIn) =>
            _UserAccounts.ReplaceOne(UserAccounts => UserAccounts.Id == id, UserAccountsIn);

        public void Remove(UserAccounts UserAccountsIn) =>
            _UserAccounts.DeleteOne(UserAccounts => UserAccounts.Id == UserAccountsIn.Id);

        public void Remove(string id) => 
            _UserAccounts.DeleteOne(UserAccounts => UserAccounts.Id == id);
    }
}