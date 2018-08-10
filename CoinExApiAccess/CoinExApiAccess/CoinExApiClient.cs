using CoinExApiAccess.Data;
using CoinExApiAccess.Data.Interface;
using CoinExApiAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoinExApiAccess
{
    public class CoinExApiClient
    {
        private ICoinExRepository _repository;

        /// <summary>
        /// Constructor - no authentication
        /// </summary>
        public CoinExApiClient()
        {
            _repository = new CoinExRepository();
        }

        /// <summary>
        /// Constructor - with authentication
        /// </summary>
        /// <param name="apiKey">Api key</param>
        /// <param name="apiSecret">Api secret</param>
        public CoinExApiClient(string apiKey, string apiSecret)
        {
            _repository = new CoinExRepository(apiKey, apiSecret);
        }

        /// <summary>
        /// Constructor - with authentication
        /// </summary>
        /// <param name="configPath">Path to config file</param>
        public CoinExApiClient(string configPath)
        {
            _repository = new CoinExRepository(configPath);
        }
        /// <summary>
        /// Get Trading Pairs
        /// </summary>
        /// <returns>Array of string of trading pairs</returns>
        public string[] GetMarketList()
        {
            return _repository.GetMarketList().Result;
        }

        /// <summary>
        /// Get Ticker for a trading pair
        /// </summary>
        /// <param name="pair">String of trading pair</param>
        /// <returns>TickerData object</returns>
        public TickerData GetTicker(string pair)
        {
            return _repository.GetTicker(pair).Result;
        }

        /// <summary>
        /// Get Market depth for a trading pair
        /// </summary>
        /// <param name="pair">String of trading pair</param>
        /// <param name="merge">Decimal places</param>
        /// <param name="limit">Return amount</param>
        /// <returns>MarketDepth object</returns>
        public MarketDepth GetMarketDepth(string pair, Merge merge = Merge.Zero, Limit limit = Limit.Twenty)
        {
            return _repository.GetMarketDepth(pair, merge, limit).Result;
        }

        /// <summary>
        /// Get Transaction data
        /// </summary>
        /// <param name="pair">String of trading pair</param>
        /// <param name="id">Transaction history id</param>
        /// <returns>Transaction object</returns>
        public Transaction GetTransactionData(string pair, int id = 0)
        {
            return _repository.GetTransactionData(pair, id).Result;
        }

        /// <summary>
        /// Get K-Line data
        /// </summary>
        /// <param name="pair">String of trading pair</param>
        /// <param name="interval">Time interval for KLines</param>
        /// <param name="limit">Number of KLines to return, (default = 10, max = 1000)</param>
        /// <returns>Array of KLine objects</returns>
        public KLine[] GetKLine(string pair, Interval interval, int limit = 10)
        {
            return _repository.GetKLine(pair, interval, limit).Result;
        }

        /// <summary>
        /// Get account balance
        /// </summary>
        /// <returns>Dictionary of Coin / value pairs</returns>
        public Dictionary<string, Asset> GetBalance()
        {
            return _repository.GetBalance().Result;
        }

        /// <summary>
        /// Get all Withdrawals from account
        /// </summary>
        /// <returns>Array of Withdrawal objects</returns>
        public Withdrawal[] GetWithdrawals()
        {
            return _repository.GetWithdrawals().Result;
        }

        /// <summary>
        /// Get Withdrawals from account by page number
        /// </summary>
        /// <param name="page">Page number to return (default = 1)</param>
        /// <returns>Array of Withdrawal objects</returns>
        public Withdrawal[] GetWithdrawals(int page = 1)
        {
            return _repository.GetWithdrawals(page).Result;
        }

        /// <summary>
        /// Get Withdrawals from account
        /// </summary>
        /// <param name="coin">Coin to return (default = "")</param>
        /// <param name="withdrawlId">Id of withdrawal to start listing (optional)</param>
        /// <param name="page">Page number to return (default = 1)</param>
        /// <param name="limit">Number of records to return (default = 10)</param>
        /// <returns>Array of Withdrawal objects</returns>
        public Withdrawal[] GetWithdrawals(string coin = "", int withdrawlId = 0, int page = 1, int limit = 10)
        {
            return _repository.GetWithdrawals(coin, withdrawlId, page, limit).Result;
        }

        /// <summary>
        /// Submit a withdrawal
        /// </summary>
        /// <param name="coin">Coin to send</param>
        /// <param name="address">Address to send to</param>
        /// <param name="amount">Amount to send</param>
        /// <returns>Withdrawal object</returns>
        public Withdrawal SubmitWithdrawal(string coin, string address, decimal amount)
        {
            return _repository.SubmitWithdrawal(coin, address, amount).Result;
        }

        /// <summary>
        /// Cancel a withdrawal
        /// </summary>
        /// <param name="id">Withdrawal request Id</param>
        /// <returns>Boolean when complete</returns>
        public bool CancelWithdrawal(long id)
        {
            return _repository.CancelWithdrawal(id).Result;
        }

        /// <summary>
        /// Post Limit Order
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="type">Trade type</param>
        /// <param name="amount">Trade amount</param>
        /// <param name="price">Trade price</param>
        /// <returns>Order object</returns>
        public Order LimitOrder(string pair, OrderType type, decimal amount, decimal price)
        {
            return _repository.LimitOrder(pair, type, amount, price).Result;
        }

        /// <summary>
        /// Post Market Order
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="type">Trade type</param>
        /// <param name="amount">Trade amount</param>
        /// <returns>Order object</returns>
        public Order MarketOrder(string pair, OrderType type, decimal amount)
        {
            return _repository.MarketOrder(pair, type, amount).Result;
        }

        /// <summary>
        /// Post IOC (Immediate-or-Cancel) Order
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="type">Trade type</param>
        /// <param name="amount">Trade amount</param>
        /// <param name="price">Trade price</param>
        /// <returns>Order object</returns>
        public Order IOCOrder(string pair, OrderType type, decimal amount, decimal price)
        {
            return _repository.IOCOrder(pair, type, amount, price).Result;
        }

        /// <summary>
        /// Get Open Orders
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="page">Page number (default = 1)</param>
        /// <param name="limit">Number of order to return (default = 10, max = 100)</param>
        /// <returns>PagedResponse with OpenOrder array</returns>
        public PagedResponse<OpenOrder[]> GetOpenOrders(string pair, int page = 1, int limit = 10)
        {
            return _repository.GetOpenOrders(pair, page, limit).Result;
        }

        /// <summary>
        /// Get an order
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="id">Order Number</param>
        /// <returns>Order object</returns>
        public Order GetOrder(string pair, int id)
        {
            return _repository.GetOrder(pair, id).Result;
        }

        /// <summary>
        /// Get completed orders
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="page">Page number (default = 1)</param>
        /// <param name="limit">Number of order to return (default = 10, max = 100)</param>
        /// <returns>PagedResponse with Order array</returns>
        public PagedResponse<Order[]> GetOrders(string pair, int page = 1, int limit = 10)
        {
            return _repository.GetOrders(pair, page, limit).Result;
        }

        /// <summary>
        /// Get user deals
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="page">Page number (default = 1)</param>
        /// <param name="limit">Number of order to return (default = 10, max = 100)</param>
        /// <returns>PagedResponse with Deal array</returns>
        public PagedResponse<Deal[]> GetUserDeals(string pair, int page = 1, int limit = 10)
        {
            return _repository.GetUserDeals(pair, page, limit).Result;
        }

        /// <summary>
        /// Cancel an order
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="id">Order Number</param>
        /// <returns>Order object</returns>
        public Order CancelOrder(string pair, int id)
        {
            return _repository.CancelOrder(pair, id).Result;
        }

        /// <summary>
        /// Get mining difficulty
        /// </summary>
        /// <returns>Current MiningDifficulty</returns>
        public MiningDifficulty GetMiningDifficulty()
        {
            return _repository.GetMiningDifficulty().Result;
        }

        /// <summary>
        /// Get Trading Pairs
        /// </summary>
        /// <returns>Array of string of trading pairs</returns>
        public async Task<string[]> GetMarketListAsync()
        {
            return await _repository.GetMarketList();
        }

        /// <summary>
        /// Get Ticker for a trading pair
        /// </summary>
        /// <param name="pair">String of trading pair</param>
        /// <returns>TickerData object</returns>
        public async Task<TickerData> GetTickerAsync(string pair)
        {
            return await _repository.GetTicker(pair);
        }

        /// <summary>
        /// Get Market depth for a trading pair
        /// </summary>
        /// <param name="pair">String of trading pair</param>
        /// <param name="merge">Decimal places</param>
        /// <param name="limit">Return amount</param>
        /// <returns>MarketDepth object</returns>
        public async Task<MarketDepth> GetMarketDepthAsync(string pair, Merge merge = Merge.Zero, Limit limit = Limit.Twenty)
        {
            return await _repository.GetMarketDepth(pair, merge, limit);
        }

        /// <summary>
        /// Get Transaction data
        /// </summary>
        /// <param name="pair">String of trading pair</param>
        /// <param name="id">Transaction history id</param>
        /// <returns>Transaction object</returns>
        public async Task<Transaction> GetTransactionDataAsync(string pair, int id = 0)
        {
            return await _repository.GetTransactionData(pair, id);
        }

        /// <summary>
        /// Get K-Line data
        /// </summary>
        /// <param name="pair">String of trading pair</param>
        /// <param name="interval">Time interval for KLines</param>
        /// <param name="limit">Number of KLines to return, (default = 10, max = 1000)</param>
        /// <returns>Array of KLine objects</returns>
        public async Task<KLine[]> GetKLineAsync(string pair, Interval interval, int limit = 10)
        {
            return await _repository.GetKLine(pair, interval, limit);
        }

        /// <summary>
        /// Get account balance
        /// </summary>
        /// <returns>Dictionary of Coin / value pairs</returns>
        public async Task<Dictionary<string, Asset>> GetBalanceAsync()
        {
            return await _repository.GetBalance();
        }

        /// <summary>
        /// Get all Withdrawals from account
        /// </summary>
        /// <returns>Array of Withdrawal objects</returns>
        public async Task<Withdrawal[]> GetWithdrawalsAsync()
        {
            return await _repository.GetWithdrawals();
        }

        /// <summary>
        /// Get Withdrawals from account by page number
        /// </summary>
        /// <param name="page">Page number to return (default = 1)</param>
        /// <returns>Array of Withdrawal objects</returns>
        public async Task<Withdrawal[]> GetWithdrawalsAsync(int page = 1)
        {
            return await _repository.GetWithdrawals(page);
        }

        /// <summary>
        /// Get Withdrawals from account
        /// </summary>
        /// <param name="coin">Coin to return (default = "")</param>
        /// <param name="withdrawlId">Id of withdrawal to start listing (optional)</param>
        /// <param name="page">Page number to return (default = 1)</param>
        /// <param name="limit">Number of records to return (default = 10)</param>
        /// <returns>Array of Withdrawal objects</returns>
        public async Task<Withdrawal[]> GetWithdrawalsAsync(string coin = "", int withdrawlId = 0, int page = 1, int limit = 10)
        {
            return await _repository.GetWithdrawals(coin, withdrawlId, page, limit);
        }

        /// <summary>
        /// Submit a withdrawal
        /// </summary>
        /// <param name="coin">Coin to send</param>
        /// <param name="address">Address to send to</param>
        /// <param name="amount">Amount to send</param>
        /// <returns>Withdrawal object</returns>
        public async Task<Withdrawal> SubmitWithdrawalAsync(string coin, string address, decimal amount)
        {
            return await _repository.SubmitWithdrawal(coin, address, amount);
        }

        /// <summary>
        /// Cancel a withdrawal
        /// </summary>
        /// <param name="id">Withdrawal request Id</param>
        /// <returns>Boolean when complete</returns>
        public async Task<bool> CancelWithdrawalAsync(long id)
        {
            return await _repository.CancelWithdrawal(id);
        }

        /// <summary>
        /// Post Limit Order
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="type">Trade type</param>
        /// <param name="amount">Trade amount</param>
        /// <param name="price">Trade price</param>
        /// <returns>Order object</returns>
        public async Task<Order> LimitOrderAsync(string pair, OrderType type, decimal amount, decimal price)
        {
            return await _repository.LimitOrder(pair, type, amount, price);
        }

        /// <summary>
        /// Post Market Order
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="type">Trade type</param>
        /// <param name="amount">Trade amount</param>
        /// <returns>Order object</returns>
        public async Task<Order> MarketOrderAsync(string pair, OrderType type, decimal amount)
        {
            return await _repository.MarketOrder(pair, type, amount);
        }

        /// <summary>
        /// Post IOC (Immediate-or-Cancel) Order
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="type">Trade type</param>
        /// <param name="amount">Trade amount</param>
        /// <param name="price">Trade price</param>
        /// <returns>Order object</returns>
        public async Task<Order> IOCOrderAsync(string pair, OrderType type, decimal amount, decimal price)
        {
            return await _repository.IOCOrder(pair, type, amount, price);
        }

        /// <summary>
        /// Get Open Orders
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="page">Page number (default = 1)</param>
        /// <param name="limit">Number of order to return (default = 10, max = 100)</param>
        /// <returns>PagedResponse with OpenOrder array</returns>
        public async Task<PagedResponse<OpenOrder[]>> GetOpenOrdersAsync(string pair, int page = 1, int limit = 10)
        {
            return await _repository.GetOpenOrders(pair, page, limit);
        }

        /// <summary>
        /// Get an order
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="id">Order Number</param>
        /// <returns>Order object</returns>
        public async Task<Order> GetOrderAsync(string pair, int id)
        {
            return await _repository.GetOrder(pair, id);
        }

        /// <summary>
        /// Get completed orders
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="page">Page number (default = 1)</param>
        /// <param name="limit">Number of order to return (default = 10, max = 100)</param>
        /// <returns>PagedResponse with Order array</returns>
        public async Task<PagedResponse<Order[]>> GetOrdersAsync(string pair, int page = 1, int limit = 10)
        {
            return await _repository.GetOrders(pair, page, limit);
        }

        /// <summary>
        /// Get user deals
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="page">Page number (default = 1)</param>
        /// <param name="limit">Number of order to return (default = 10, max = 100)</param>
        /// <returns>PagedResponse with Deal array</returns>
        public async Task<PagedResponse<Deal[]>> GetUserDealsAsync(string pair, int page = 1, int limit = 10)
        {
            return await _repository.GetUserDeals(pair, page, limit);
        }

        /// <summary>
        /// Cancel an order
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="id">Order Number</param>
        /// <returns>Order object</returns>
        public async Task<Order> CancelOrderAsync(string pair, int id)
        {
            return await _repository.CancelOrder(pair, id);
        }

        /// <summary>
        /// Get mining difficulty
        /// </summary>
        /// <returns>Current MiningDifficulty</returns>
        public async Task<MiningDifficulty> GetMiningDifficultyAsync()
        {
            return await _repository.GetMiningDifficulty();
        }
    }
}
