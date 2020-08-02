using System.Collections.Generic;

namespace CoinKeeperApiClient.Client.Models
{
    /// <summary>
    /// <example>
    /// {
    ///     "userId": "",
    ///     "skip": 100,
    ///     "take": 20,
    ///     "categoryIds": ["9778434e076f42b184a49dd7c5094c10"],
    ///     "tagIds": [],
    ///     "period": {
    ///         "from": "2020-02-01T00:00:00.000Z",
    ///         "to": "2020-02-29T23:59:59.999Z"
    ///     }
    /// }
    /// </example>
    /// 
    /// </summary>
    public class GetTransactionsRequest
    {
        public GetTransactionsRequest(string userId)
        {
            CategoryIds = new List<string>();
            TagIds = new List<string>();
            UserId = userId;
        }
            
        public string UserId { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public List<string> CategoryIds { get; set; }
        public List<string> TagIds { get; set; }
        public Period Period { get; set; }
    }
}