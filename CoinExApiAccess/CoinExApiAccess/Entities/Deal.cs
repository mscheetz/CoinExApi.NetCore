using System;
using System.Collections.Generic;
using System.Text;

namespace CoinExApiAccess.Entities
{
    public class Deal
    {
        public decimal amount { get; set; }
        public long create_time { get; set; }
        public decimal deal_money { get; set; }
        public decimal fee { get; set; }
        public string fee_asset { get; set; }
        public long id { get; set; }
        public long order_id { get; set; }
        public decimal price { get; set; }
        public string role { get; set; }
        public string type { get; set; }
    }
}
