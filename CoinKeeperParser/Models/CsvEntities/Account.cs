namespace CoinKeeperParser.Models.CsvEntities
{
    /// <summary>
    /// <remarks>
    /// "Название","Текущее значение","Иконка","Валюта"
    /// </remarks>
    /// </summary>
    public class Account
    {
        public string Name;
        public decimal CurrentValue;
        public string Icon;
        public string Currency;
    }
}