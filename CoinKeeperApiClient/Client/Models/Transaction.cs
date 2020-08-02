using System;
using System.Collections.Generic;

namespace CoinKeeperApiClient.Client.Models
{
    public class Transaction
    {
        public string Id;
        public string ImportedTransactionId;
        public string UserId;
        public long DateTimestamp; // 637166304000000000
        public DateTime DateTimestampIso; // "2020-02-07T00:00:00Z"
        public decimal DefaultAmount; 
        public bool Deleted;
        public long CreatedTimestamp;
        public DateTime CreatedTimestampISO;
        public long Timestamp;
        public DateTime  TimestampIso;
        public string SourceId;
        public int SourceType;
        public decimal SourceAmount;
        public string DestinationId;
        public int DestinationType;
        public decimal DestinationAmount;
        public List<string> Tags;
        public string Comment;
        public decimal DebtPaymentAmount;
        public string DebtorCreditor;
        public long DebtDeadLine;
        public DateTime DebtDeadLineIso;
        public long DebtPaymentDate;
        public DateTime DebtPaymentDateISO;
        public string DebtPaymentTransactionId;
        public bool Duplicated;
        public bool Processed;
        public bool IsComplete;
        public string RepeatingParentId;
        public int Counter;
    }
}