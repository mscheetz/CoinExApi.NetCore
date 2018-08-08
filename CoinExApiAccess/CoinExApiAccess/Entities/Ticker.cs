using System;
using System.Collections.Generic;
using System.Text;

namespace CoinExApiAccess.Entities
{
    public class Ticker
    {
        public decimal buy { get; set; }
        public decimal buy_amount { get; set; }
        public decimal open { get; set; }
        public decimal high { get; set; }
        public decimal last { get; set; }
        public decimal low { get; set; }
        public decimal sell { get; set; }
        public decimal sell_amount { get; set; }
        public decimal vol { get; set; }
    }
}
