using System;
using System.Collections.Generic;
using System.Text;

namespace CoinExApiAccess.Entities
{
    public class OrderRequest
    {
        public string access_id { get; set; }
        public decimal amount { get; set; }
        public string market { get; set; }
        public decimal price { get; set; }
        public string source_id { get; set; }
        public long tonce { get; set; }
        public string type { get; set; }
    }
}
