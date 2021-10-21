namespace CSGAPI.Models
{
    public class ATMBalanceDBSettings : IATMBalanceDBSettings {
        public string ATMBalanceCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IATMBalanceDBSettings {
        string ATMBalanceCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}