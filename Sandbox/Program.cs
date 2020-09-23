using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoinKeeperApiClient;
using CoinKeeperApiClient.Client.Models;
using CoinKeeperParser;
using CoinKeeperParser.Models;

namespace Sandbox
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            await ExportFromApi();

            ExportFromCSV();
            
            Console.ReadKey();
        }

        private static void ExportFromCSV()
        {
            Console.WriteLine("Start CSV parser");
            var coinKeeperCsvParser = new CoinKeeperCsvParser();
            CoinKeeperCsvData data = coinKeeperCsvParser
                .Parse(@"INSERT_PATH_TO_CSV_FILE_HERE");
            // TODO: process data

            Console.WriteLine("Finish");
        }

        private static async Task ExportFromApi()
        {
            Console.WriteLine("Start");

            // TODO: realize auth ang getting cookie "__AUTH_cookie" (need solve google captcha)
            string authCookie = "AUTH_COOKIE_VALUE";

            ICoinKeeperClient coinKeeperClient = new CoinKeeperClient(authCookie);
            var manager = new CoinKeeperManager(coinKeeperClient);

            List<Transaction> transactions;
            try
            {
                transactions = await manager.ExportData(new DateTime(2018, 01, 01), DateTime.Today);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in {nameof(CoinKeeperManager.ExportData)}", e);
            }

            Console.WriteLine("Finish API Client");
            // TODO: save transactions
        }
    }
}