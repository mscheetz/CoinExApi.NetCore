using System;
using System.Collections.Generic;
using System.Text;

namespace CoinExApiAccess.Entities
{
    public class OpenOrder
    {
        public decimal amount { get; set; }
        public decimal avg_price { get; set; }
        public long create_time { get; set; }
        public decimal deal_amount { get; set; }
        public decimal deal_fee { get; set; }
        public decimal deal_money { get; set; }
        public long id { get; set; }
        public decimal left { get; set; }
        public decimal maker_fee_rate { get; set; }
        public string market { get; set; }
        public string order_type { get; set; }
        public decimal price { get; set; }
        public string status { get; set; }
        public decimal taker_fee_rate { get; set; }
        public string type { get; set; }
    }
}
