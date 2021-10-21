namespace CSGAPI.Models
{
    public class UserAccountsDBSettings : IUserAccountsDBSettings {
        public string UserAccountsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IUserAccountsDBSettings {
        string UserAccountsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}