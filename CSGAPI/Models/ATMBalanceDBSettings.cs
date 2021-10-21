namespace CSGAPI.Models
{
    public class ATMBalanceDBSettings : IATMBalanceDBSettings {
        public string ATMBalancetCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string ATMBalanceDatabaseName { get; set; }
    }

    public interface IATMBalanceDBSettings {
        string ATMBalancetCollectionName { get; set; }
        string ConnectionString { get; set; }
        string ATMBalanceDatabaseName { get; set; }
    }
}