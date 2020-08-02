using System.Collections.Generic;
using CoinKeeperApiClient.Client.Models;

namespace CoinKeeperApiClient.Client.Models
{
    public class TransactionsResponse
    {
        public List<Transaction> Transactions;
        public List<dynamic> ImportedTransactions;
        public bool HasMoreData;
    }
}