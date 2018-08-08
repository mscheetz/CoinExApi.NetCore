using System;
using System.Collections.Generic;
using System.Text;

namespace CoinExApiAccess.Entities
{
    public class Transaction
    {
        public int id { get; set; }
        public long date { get; set; }
        public long date_ms { get; set; }
        public decimal amount { get; set; }
        public decimal price { get; set; }
        public string type { get; set; }
    }
}
