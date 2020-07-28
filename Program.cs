using System;
using CoinKeeperParser.Models;

namespace CoinKeeperParser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Start");
            var coinKeeperCsvParser = new CoinKeeperCsvParser();
            CoinKeeperCsvData data = coinKeeperCsvParser
                .Parse(@"INSERT_PATH_TO_CSV_FILE_HERE");

            Console.WriteLine(data.Accounts);
            Console.WriteLine("Finish");
            Console.ReadKey();
        }
    }
}