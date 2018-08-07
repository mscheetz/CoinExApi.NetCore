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
        private string configPath = "";
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
    }
}
