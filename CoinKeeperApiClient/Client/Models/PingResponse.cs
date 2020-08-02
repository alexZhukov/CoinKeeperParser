using System.Collections.Generic;

namespace CoinKeeperApiClient.Client.Models
{
    public class PingResponse
    {
        public UserInfo UserInfo;
        public List<Category> Accounts;
        public List<string> Tags;
        public PeriodStat PeriodStatistic;
    }
}