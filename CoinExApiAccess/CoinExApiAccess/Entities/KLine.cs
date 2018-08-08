using CoinExApiAccess.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinExApiAccess.Entities
{
    [JsonConverter(typeof(Converter.ObjectToArrayConverter<KLine>))]
    public class KLine
    {
        [JsonProperty(Order = 1)]
        public long date { get; set; }
        [JsonProperty(Order = 2)]
        public decimal open { get; set; }
        [JsonProperty(Order = 3)]
        public decimal close { get; set; }
        [JsonProperty(Order = 4)]
        public decimal high { get; set; }
        [JsonProperty(Order = 5)]
        public decimal low { get; set; }
        [JsonProperty(Order = 6)]
        public decimal volume { get; set; }
        [JsonProperty(Order = 7)]
        public decimal amount { get; set; }
        [JsonProperty(Order = 8)]
        public string market { get; set; }
    }
}
