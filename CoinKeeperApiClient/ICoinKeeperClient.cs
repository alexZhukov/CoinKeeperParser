using System.Threading.Tasks;
using CoinKeeperApiClient.Client.Models;

namespace CoinKeeperApiClient
{
    /// <summary>
    /// Interface for Api client CoinKeeper
    /// </summary>
    public interface ICoinKeeperClient
    {
        /// <summary>
        /// method ping
        /// </summary>
        /// <returns>Return base userInfo, tags and categories <see cref="PingResponse"/> </returns>
        Task<PingResponse> Ping();
        
        /// <summary>
        /// Get transactions by parameters <see cref="GetTransactionsRequest"/>
        /// </summary>
        /// <param name="request">Params and filters for getting transactions</param>
        /// <returns></returns>
        Task<TransactionsResponse> GetTransactions(GetTransactionsRequest request);
    }
}