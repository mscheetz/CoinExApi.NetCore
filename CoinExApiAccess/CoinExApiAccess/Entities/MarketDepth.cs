using System;
using System.Collections.Generic;
using System.Text;

namespace CoinExApiAccess.Entities
{
    public class MarketDepth
    {
        public decimal last { get; set; }
        public Depth[] asks { get; set; }
        public Depth[] bids { get; set; }
    }
}
