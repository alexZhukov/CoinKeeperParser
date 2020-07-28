namespace CoinKeeperParser.Models.CsvEntities
{
    /// <summary>
    /// <remarks>
    /// "Название","Бюджет","Получено","Иконка","Валюта"
    /// </remarks>
    /// </summary>
    public class IncomingAccount
    {
        public string Name;
        public decimal Budget;
        public decimal IncomingSum;
        public string Icon;
        public string Currency;
    }
}