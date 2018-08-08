using CoinExApiAccess.Core;
using Newtonsoft.Json;

namespace CoinExApiAccess.Entities
{
    [JsonConverter(typeof(Converter.ObjectToArrayConverter<Depth>))]
    public class Depth
    {
        [JsonProperty(Order = 1)]
        public decimal orderPrice { get; set; }
        [JsonProperty(Order = 2)]
        public decimal orderAmount { get; set; }
    }
}
