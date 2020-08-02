using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CoinKeeperApiClient.Client.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoinKeeperApiClient
{
    public class CoinKeeperClient : ICoinKeeperClient
    {
        private enum CoinkeeperKey
        {
            UserInfo = 0,
            Accounts = 2,
            Tags = 3,
            Currencies = 4,
            PeriodStatistic = 5,
            Icons = 6
        }
        
        private class PingResponseItem
        {
            public string EntityJson { get; set; }
            public CoinkeeperKey Key { get; set; }
        }

        private const string HOST = "https://coinkeeper.me";

        private readonly string _authCookie;
        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// </summary>
        /// <param name="authCookie">значение авторизационной cookie __AUTH_cookie для домена coinkeeper.me</param>
        public CoinKeeperClient(string authCookie)
        {
            _authCookie = authCookie;
        }

        public async Task<PingResponse> Ping()
        {
            var message = CreateHttpRequest(HttpMethod.Post, $"{HOST}/Exchange/Ping");
            string postContent =
                "{\"items\":[{\"key\":0,\"entityJson\":null},{\"key\":1,\"entityJson\":null},{\"key\":2,\"entityJson\":null},{\"key\":3,\"entityJson\":null},{\"key\":4,\"entityJson\":null},{\"key\":5,\"entityJson\":null},{\"key\":6,\"entityJson\":null}]}";
            message.Content = new StringContent(postContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.SendAsync(message);
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();

            JToken jToken = JToken.Parse(responseContent);
            JArray jArray = jToken["data"]["items"] as JArray;

            Dictionary<CoinkeeperKey, string> jsonByKey = jArray
                .ToObject<List<PingResponseItem>>()
                .ToDictionary(x => x.Key, x => x.EntityJson);
            var result = new PingResponse();

            result.UserInfo = JsonConvert.DeserializeObject<UserInfo>(jsonByKey[CoinkeeperKey.UserInfo]);
            result.Accounts = JsonConvert.DeserializeObject<List<Category>>(jsonByKey[CoinkeeperKey.Accounts]);
            result.Tags = JsonConvert.DeserializeObject<List<string>>(jsonByKey[CoinkeeperKey.Tags]);
            result.PeriodStatistic = JsonConvert.DeserializeObject<PeriodStat>(jsonByKey[CoinkeeperKey.PeriodStatistic]);
            return result;
        }

        public async Task<TransactionsResponse> GetTransactions(GetTransactionsRequest request)
        {
            var message = CreateHttpRequest(HttpMethod.Post, $"{HOST}/api/transaction/get");

            string postContent = JsonConvert.SerializeObject(request);
            message.Content = new StringContent(postContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.SendAsync(message);
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();

            TransactionsResponse result = JsonConvert.DeserializeObject<TransactionsResponse>(responseContent);
            return result;
        }

        private HttpRequestMessage CreateHttpRequest(HttpMethod method, string requestUri)
        {
            var message = new HttpRequestMessage(method, requestUri);
            message.Headers.Add("Cookie", $"__AUTH_cookie={_authCookie};");
            HttpRequestHeaders headers = message.Headers;
            headers.UserAgent.TryParseAdd(
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36;");
            return message;
        }
    }
}