using CoinExApiAccess.Core;
using CoinExApiAccess.Data.Interface;
using CoinExApiAccess.Entities;
using DateTimeHelpers;
using FileRepository;
using RESTApiAccess;
using RESTApiAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinExApiAccess.Data
{
    public class CoinExRepository : ICoinExRepository
    {
        private Security security;
        private IRESTRepository _restRepo;
        private DateTimeHelper _dtHelper;
        private ApiInformation _apiInfo = null;
        private string baseUrl;

        /// <summary>
        /// Constructor for non-signed endpoints
        /// </summary>
        public CoinExRepository()
        {
            LoadRepository();
        }

        /// <summary>
        /// Constructor for signed endpoints
        /// </summary>
        /// <param name="apiKey">Api key</param>
        /// <param name="apiSecret">Api secret</param>
        public CoinExRepository(string apiKey, string apiSecret)
        {
            _apiInfo = new ApiInformation
            {
                apiKey = apiKey,
                apiSecret = apiSecret
            };
            LoadRepository();
        }

        /// <summary>
        /// Constructor for signed endpoints
        /// </summary>
        /// <param name="configPath">String of path to configuration file</param>
        public CoinExRepository(string configPath)
        {
            IFileRepository _fileRepo = new FileRepository.FileRepository();

            if (_fileRepo.FileExists(configPath))
            {
                _apiInfo = _fileRepo.GetDataFromFile<ApiInformation>(configPath);
                LoadRepository();
            }
            else
            {
                throw new Exception("Config file not found");
            }
        }

        /// <summary>
        /// Load repository
        /// </summary>
        /// <param name="key">Api key value (default = "")</param>
        /// <param name="secret">Api secret value (default = "")</param>
        private void LoadRepository(string key = "", string secret = "")
        {
            security = new Security();
            _restRepo = new RESTRepository();
            baseUrl = "https://api.coinex.com/v1";
            _dtHelper = new DateTimeHelper();
        }

        /// <summary>
        /// Check if the Exchange Repository is ready for trading
        /// </summary>
        /// <returns>Boolean of validation</returns>
        public bool ValidateExchangeConfigured()
        {
            var ready = _apiInfo == null || string.IsNullOrEmpty(_apiInfo.apiKey) ? false : true;
            if (!ready)
                return false;

            return string.IsNullOrEmpty(_apiInfo.apiSecret) ? false : true;
        }

        public async Task<string[]> GetMarketList()
        {
            var endpoint = "/market/list";
            var url = baseUrl + endpoint;

            var response = await _restRepo.GetApiStream<ResponseMessage<string[]>>(url);

            return response.data;
        }

        /// <summary>
        /// Get Request Headers
        /// </summary>
        /// <returns>Dictionary of header values</returns>
        private Dictionary<string, string> GetRequestHeaders(List<string> queryString)
        {
            var headers = new Dictionary<string, string>();
            headers.Add("authorization", SignMessage(queryString));

            return headers;
        }

        /// <summary>
        /// Get signature of message
        /// </summary>
        /// <param name="queryString">String[] of querystring values</param>
        /// <returns>String of message signature</returns>
        private string SignMessage(List<string> queryString)
        {
            var qsValues = string.Empty;
            var timestamp = _dtHelper.UTCtoUnixTimeMilliseconds();
            var timeStampQS = $"tonce={timestamp}";
            if (queryString != null)
            {
                queryString.Add(timeStampQS);
                queryString = queryString.OrderBy(q => q).ToList();
                for (int i = 0; i < queryString.Count; i++)
                {
                    qsValues += qsValues != string.Empty ? "&" : "";
                    qsValues += queryString[i];
                }
            }
            var hmac = security.GetHMACSignature(qsValues, _apiInfo.apiSecret);

            return hmac;
        }

        /// <summary>
        /// Create a Binance url
        /// </summary>
        /// <param name="apiPath">String of path to endpoint</param>
        /// <param name="secure">Boolean if secure endpoin (default = true)</param>
        /// <param name="queryString">String[] of querystring values</param>
        /// <returns>String of url</returns>
        private string CreateUrl(string apiPath, bool secure = true, List<string> queryString = null)
        {
            var qsValues = string.Empty;
            var url = string.Empty;
            var timestamp = _dtHelper.UTCtoUnixTimeMilliseconds();
            var timeStampQS = $"tonce={timestamp}";
            if (queryString != null)
            {
                queryString.Add(timeStampQS);
                queryString = queryString.OrderBy(q => q).ToList();
                for (int i = 0; i < queryString.Count; i++)
                {
                    qsValues += qsValues != string.Empty ? "&" : "";
                    qsValues += queryString[i];
                }
            }
            if (!secure)
            {
                url = baseUrl + $"{apiPath}";
                if (qsValues != string.Empty)
                    url += "?" + qsValues;

                return url;
            }
            var hmac = security.GetHMACSignature(qsValues, _apiInfo.apiSecret);

            url = baseUrl + $"{apiPath}?{qsValues}&signature={hmac}";

            return url;
        }
    }
}
