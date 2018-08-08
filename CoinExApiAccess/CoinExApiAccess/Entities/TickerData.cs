using System;
using System.Collections.Generic;
using System.Text;

namespace CoinExApiAccess.Entities
{
    public class TickerData
    {
        public long date { get; set; }
        public Ticker ticker { get; set; }
    }
}
