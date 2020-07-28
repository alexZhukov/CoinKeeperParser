using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CoinKeeperParser.Helpers;
using CoinKeeperParser.Models;
using CsvHelper;

namespace CoinKeeperParser
{
    public class CoinKeeperCsvParser
    {
        public CoinKeeperCsvData Parse(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException(filepath);
            }

            var fileStructure = new CoinKeeperFileStructure();
            using (var reader = new StreamReader(filepath))
            {
                while (!reader.EndOfStream)
                {
                    // пропускаем первую строчку
                    reader.ReadLine();
                    fileStructure.Operations = ReadSection(reader);
                    fileStructure.Incoming = ReadSection(reader);
                    fileStructure.Accounts = ReadSection(reader);
                    fileStructure.Categories = ReadSection(reader);
                    fileStructure.Tags = ReadSection(reader);
                }
            }
                 
            var data = new CoinKeeperCsvData();
            data.Operations = ParseRow(fileStructure.Operations, CoinKeeperParserHelper.OperationSelector);
            data.Incoming = ParseRow(fileStructure.Incoming, CoinKeeperParserHelper.IncomingAccountSelector);
            data.Categories = ParseRow(fileStructure.Categories, CoinKeeperParserHelper.CategorySelector);
            data.Accounts = ParseRow(fileStructure.Accounts, CoinKeeperParserHelper.AccountSelector);
            data.Tags = ParseRow(fileStructure.Tags, CoinKeeperParserHelper.TagSelector);
            return data;
        }

        private string ReadSection(StreamReader reader)
        {
            StringBuilder sb = new StringBuilder();

            if (reader.EndOfStream)
            {
                return sb.ToString();
            }

            string header = reader.ReadLine();
            sb.AppendLine(header);
            while (!reader.EndOfStream)
            {
                long position = reader.GetPosition();
                var str = reader.ReadLine();
                if (!string.IsNullOrWhiteSpace(str) 
                    && (str.StartsWith("\"Название\"") 
                        || str.StartsWith("\"Данные\"")))
                {
                    reader.SetPosition(position);
                    return sb.ToString();
                }

                sb.AppendLine(str);
            }

            return sb.ToString();
        }

        private List<T> ParseRow<T>(string row, Func<Dictionary<string, string>, T> rowSelector) where T : class, new()
        {
            byte[] bytes = Encoding.UTF8.GetBytes(row);
            using (var stream = new MemoryStream(bytes))
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                IEnumerable<dynamic> records = csv.GetRecords<dynamic>();

                List<T> result = records
                    .Select(rowData =>
                    {
                        var enumerable = rowData as IEnumerable<KeyValuePair<string, object>>;
                        if (enumerable == null)
                        {
                            return null;
                        }

                        var dict = enumerable.ToDictionary(x => x.Key, x => (string)x.Value);
                            T data = rowSelector(dict);
                            return data;
                        }) 
                    .ToList();
                
                return result;
            }
        }
        
        private class CoinKeeperFileStructure
        {
            public string Categories;
            public string Incoming;
            public string Operations;
            public string Accounts;
            public string Tags;
        }
    }
}