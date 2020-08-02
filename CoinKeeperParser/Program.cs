using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoinKeeperApiClient;
using CoinKeeperApiClient.Client.Models;
using CoinKeeperParser.Models;

namespace CoinKeeperParser
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Start");
            string authCookie = "PLACE_COOKIE_VALUE_HERE";
            var webDataGetter = new CoinKeeperClient(authCookie);
            PingResponse pingResponse = await webDataGetter.Ping();

            string userId = pingResponse.UserInfo.UserId;
            GetTransactionsRequest request = new GetTransactionsRequest(userId) {
                Take = 20,
                Skip = 0,
                Period = new Period
                {
                    From = new DateTime(2020, 02, 01),
                    To = new DateTime(2020, 03, 01),
                }
            };
            //var transactionsResponse = await webDataGetter.GetTransactions(request);

            var result = await GetAllTransactionsForPeriod(webDataGetter, userId, new DateTime(2020, 02, 01), new DateTime(2020, 03, 01));
            
            var coinKeeperCsvParser = new CoinKeeperCsvParser();
            CoinKeeperCsvData data = coinKeeperCsvParser
                .Parse(@"INSERT_PATH_TO_CSV_FILE_HERE");

            Console.WriteLine(data.Accounts);
            Console.WriteLine("Finish");
            Console.ReadKey();
        }


        public static async Task<List<Transaction>> GetAllTransactionsForPeriod(CoinKeeperClient coinKeeperClient, 
            string userId, DateTime startDate, DateTime endDate)
        {
            int skip = 0;
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
                transactionsResponse = await coinKeeperClient.GetTransactions(request);
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