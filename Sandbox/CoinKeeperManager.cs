using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoinKeeperApiClient;
using CoinKeeperApiClient.Client.Models;

namespace Sandbox
{
    public class CoinKeeperManager
    {
        private readonly ICoinKeeperClient _coinKeeperClient;

        public CoinKeeperManager(ICoinKeeperClient coinKeeperClient)
        {
            _coinKeeperClient = coinKeeperClient;
        }

        /// <summary>
        /// Export transactions history for period from <paramref name="from"/> to <paramref name="to"/>
        /// </summary>
        /// <param name="from">Date from</param>
        /// <param name="to">date to</param>
        /// <returns></returns>
        public async Task<List<Transaction>> ExportData(DateTime from, DateTime to)
        {
            PingResponse pingResponse = await _coinKeeperClient.Ping();

            string userId = pingResponse.UserInfo.UserId;
            GetTransactionsRequest request = new GetTransactionsRequest(userId) {
                Take = 20,
                Skip = 0,
                Period = new Period
                {
                    From = from,
                    To = to,
                }
            };

            List<Transaction> result = await GetAllTransactionsForPeriod(userId, from, to);
            return result;
        }
        
        private async Task<List<Transaction>> GetAllTransactionsForPeriod(string userId, DateTime startDate, DateTime endDate)
        {
            int skip = 0;
            // API has no limit, this value equal value from coinkeeper web version
            const int STEP_SIZE = 20;

            List<Transaction> result = new List<Transaction>();
            TransactionsResponse transactionsResponse;
            do
            {
                GetTransactionsRequest request = new GetTransactionsRequest(userId) {
                    Take = STEP_SIZE,
                    Skip = skip,
                    Period = new Period
                    {
                        From = startDate,
                        To = endDate
                    }
                };
                transactionsResponse = await _coinKeeperClient.GetTransactions(request);
                if (transactionsResponse?.Transactions.Count > 0)
                {
                    result.AddRange(transactionsResponse.Transactions);
                }

                skip += STEP_SIZE;
                await Task.Delay(TimeSpan.FromSeconds(2));
            } while (transactionsResponse != null && transactionsResponse.HasMoreData);

            return result;
        }
    }
}