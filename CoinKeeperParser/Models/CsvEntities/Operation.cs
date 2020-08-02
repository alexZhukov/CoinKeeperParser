using System;

namespace CoinKeeperParser.Models.CsvEntities
{
    /// <summary>
    /// <remarks>
    ///  "Данные","Тип","Из","В","Метки","Сумма","Валюта","Сумма в др.валюте","Др.валюта","Повторение","Заметка"
    /// </remarks>
    /// </summary>
    public class Operation
    {
        /// <summary>
        ///     Дата
        /// </summary>
        public DateTime Date;

        /// <summary>
        ///     Из
        /// </summary>
        public string From;

        /// <summary>
        ///     В
        /// </summary>
        public string To;

        /// <summary>
        ///     Валюта
        /// </summary>
        public string Currency;

        /// <summary>
        ///     Заметка
        /// </summary>
        public string Note;

        /// <summary>
        ///     Заметка
        /// </summary>
        public string Tags;
        
        /// <summary>
        ///     Тип операции
        /// </summary>
        public string OperationType;

        /// <summary>
        ///     Другая валюта
        /// </summary>
        public string OtherCurrency;

        /// <summary>
        ///     Повторение
        /// </summary>
        public string RepeatSettings;

        /// <summary>
        ///     Сумма
        /// </summary>
        public decimal Sum;

        /// <summary>
        ///     Сумма в другой валюте
        /// </summary>
        public decimal SumInOtherCurrency;

    }
}