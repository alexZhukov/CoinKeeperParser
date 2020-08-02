using System;
using CoinKeeperApiClient.Helpers;

namespace CoinKeeperApiClient.Client.Models
{
    public class Category
    {
        public decimal Amount;
        public bool BankLinked;
        public int CategoryType;
        public long CreatedTimestamp;
        public DateTime CreateTime => CreatedTimestamp.TicksToDateTime();
        public string CurrencyId;
        public decimal CurrentAmount;
        public bool Deleted;
        public bool DeletedWithTransactions;
        public bool ExceptFromBalance;
        public bool Free;
        public bool GoalClosed;
        public long GoalClosedDate;
        public bool HasMultipleSources;
        public string Icon;
        public string Id;
        public decimal LimitAmount;
        public string Name;
        public int Order;
        public string ParentUid;
        public decimal PeriodizedLimitAmount;
    }
}