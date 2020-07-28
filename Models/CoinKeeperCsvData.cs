using System.Collections.Generic;
using CoinKeeperParser.Models.CsvEntities;

namespace CoinKeeperParser.Models
{
    public class CoinKeeperCsvData
    {
        public List<Category> Categories;
        public List<IncomingAccount> Incoming;
        public List<Operation> Operations;
        public List<Account> Accounts;
        public List<Tag> Tags;
    }
}