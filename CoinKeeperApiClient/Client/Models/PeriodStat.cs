using System;
using System.Collections.Generic;

namespace CoinKeeperApiClient.Client.Models
{
    public class PeriodStat
    {
        public int PeriodNumber;
        public DateTime StartDay;
        public int TotalNumberOfDaysInPeriod;
        public int CurrentNumberOfDaysInPeriod;
        public int MinTransactionsCountForRedColor;
        public string Period;
        public decimal ExpenseSpentBalance;
        public List<PeriodCategoryCount> Counts;
    }
}