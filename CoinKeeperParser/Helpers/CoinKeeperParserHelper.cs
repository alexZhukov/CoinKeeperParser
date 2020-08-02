using System;
using System.Collections.Generic;
using CoinKeeperParser.Models.CsvEntities;

namespace CoinKeeperParser.Helpers
{
    internal static class CoinKeeperParserHelper
    {
        public static Func<Dictionary<string, string>, Operation> OperationSelector = d => new Operation
        {
            Date = DateTime.Parse(d["Данные"]),
            OperationType = d["Тип"],
            From = d["Из"],
            To = d["В"],
            Tags = d["Метки"],
            Sum = decimal.Parse(d["Сумма"]),
            Currency = d["Валюта"],
            SumInOtherCurrency = decimal.Parse(d["Сумма в др.валюте"]),
            OtherCurrency = d["Др.валюта"],
            RepeatSettings = d["Повторение"],
            Note = d["Заметка"],
        };
        
        public static Func<Dictionary<string, string>, IncomingAccount> IncomingAccountSelector = d => new IncomingAccount
        {
            Name = d["Название"],
            Budget = decimal.Parse(d["Бюджет"]),
            IncomingSum = decimal.Parse(d["Получено"]),
            Icon = d["Иконка"],
            Currency = d["Валюта"],
        };
        
        public static Func<Dictionary<string, string>, Category> CategorySelector = d => new Category
        {
            Name = d["Название"],
            Budget = decimal.Parse(d["Бюджет"]),
            IncomingSum = decimal.Parse(d["Получено"]),
            Icon = d["Иконка"],
            Currency = d["Валюта"],
        };                    
        
        public static Func<Dictionary<string, string>, Account> AccountSelector = d => new Account
        {
            //"Название","Текущее значение","Иконка","Валюта"
            Name = d["Название"],
            CurrentValue = decimal.Parse(d["Текущее значение"]),
            Icon = d["Иконка"],
            Currency = d["Валюта"],
        };
        
        public static Func<Dictionary<string, string>, Tag> TagSelector = d => new Tag
        {
            Name = d["Название"],
            Sum = decimal.Parse(d["Получено"]),
        };
    }
}