using CoinExApiAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoinExApiAccess.Data.Interface
{
    public interface ICoinExRepository
    {
        /// <summary>
        /// Get Trading Pairs
        /// </summary>
        /// <returns>Array of string of trading pairs</returns>
        Task<string[]> GetMarketList();

        /// <summary>
        /// Get Ticker for a trading pair
        /// </summary>
        /// <param name="pair">String of trading pair</param>
        /// <returns>TickerData object</returns>
        Task<TickerData> GetTicker(string pair);

        /// <summary>
        /// Get Market depth for a trading pair
        /// </summary>
        /// <param name="pair">String of trading pair</param>
        /// <param name="merge">Decimal places</param>
        /// <param name="limit">Return amount</param>
        /// <returns>MarketDepth object</returns>
        Task<MarketDepth> GetMarketDepth(string pair, Merge merge = Merge.Zero, Limit limit = Limit.Twenty);
        
        /// <summary>
        /// Get Transaction data
        /// </summary>
        /// <param name="pair">String of trading pair</param>
        /// <param name="id">Transaction history id</param>
        /// <returns>Transaction object</returns>
        Task<Transaction> GetTransactionData(string pair, int id = 0);

        /// <summary>
        /// Get K-Line data
        /// </summary>
        /// <param name="pair">String of trading pair</param>
        /// <param name="interval">Time interval for KLines</param>
        /// <param name="limit">Number of KLines to return, max 1000</param>
        /// <returns>Array of KLine objects</returns>
        Task<KLine[]> GetKLine(string pair, Interval interval, int limit = 1000);

        /// <summary>
        /// Get account balance
        /// </summary>
        /// <returns>Dictionary of Coin / value pairs</returns>
        Task<Dictionary<string, Asset>> GetBalance();

        /// <summary>
        /// Get all Withdrawals from account
        /// </summary>
        /// <returns>Array of Withdrawal objects</returns>
        Task<Withdrawal[]> GetWithdrawals();

        /// <summary>
        /// Get Withdrawals from account by page number
        /// </summary>
        /// <param name="page">Page number to return (default = 1)</param>
        /// <returns>Array of Withdrawal objects</returns>
        Task<Withdrawal[]> GetWithdrawals(int page = 1);

        /// <summary>
        /// Get Withdrawals from account
        /// </summary>
        /// <param name="coin">Coin to return (default = "")</param>
        /// <param name="withdrawlId">Id of withdrawal to start listing (optional)</param>
        /// <param name="page">Page number to return (default = 1)</param>
        /// <param name="limit">Number of records to return (default = 100)</param>
        /// <returns>Array of Withdrawal objects</returns>
        Task<Withdrawal[]> GetWithdrawals(string coin = "", int withdrawlId = 0, int page = 1, int limit = 100);
    }
}
