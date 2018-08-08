using CoinExApiAccess.Data;
using CoinExApiAccess.Data.Interface;
using CoinExApiAccess.Entities;
using FileRepository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoinExApiAccess.Tests
{
    public class CoinExRepositoryTests : IDisposable
    {
        private ApiInformation _exchangeApi = null;
        private ICoinExRepository _repo;
        private string configPath = "config.json";
        private string apiKey = string.Empty;
        private string apiSecret = string.Empty;

        /// <summary>
        /// Constructor for tests
        /// </summary>
        public CoinExRepositoryTests()
        {
            IFileRepository _fileRepo = new FileRepository.FileRepository();
            if (_fileRepo.FileExists(configPath))
            {
                _exchangeApi = _fileRepo.GetDataFromFile<ApiInformation>(configPath);
            }
            if (_exchangeApi != null || !string.IsNullOrEmpty(apiKey))
            {
                _repo = new CoinExRepository(_exchangeApi.apiKey, _exchangeApi.apiSecret);
            }
            else
            {
                _repo = new CoinExRepository();
            }
        }

        public void Dispose()
        {

        }

        [Fact]
        public void GetMarketListTest()
        {
            var markets = _repo.GetMarketList().Result;

            Assert.NotNull(markets);
        }

        [Fact]
        public void GetTickerTest()
        {
            var pair = "CETBTC";
            var ticker = _repo.GetTicker(pair).Result;

            Assert.NotNull(ticker);
        }

        [Fact]
        public void GetMarketDepthTest()
        {
            var pair = "CETBTC";
            var ticker = _repo.GetMarketDepth(pair).Result;

            Assert.NotNull(ticker);
        }

        [Fact]
        public void GetTransactionTest()
        {
            var pair = "CETBTC";
            var transactionData = _repo.GetTransactionData(pair, 2).Result;

            Assert.NotNull(transactionData);
        }

        [Fact]
        public void GetKlineTest()
        {
            var pair = "CETBTC";
            var transactionData = _repo.GetKLine(pair, Interval.OneH, 100).Result;

            Assert.NotNull(transactionData);
        }

        [Fact]
        public void GetBalanceTest()
        {
            var balance = _repo.GetBalance().Result;

            Assert.NotNull(balance);
        }

        [Fact]
        public void GetWithdrawalsTest()
        {
            var withdrawals = _repo.GetWithdrawals().Result;

            Assert.NotNull(withdrawals);
        }
    }
}
