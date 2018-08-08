using System;
using System.Collections.Generic;
using System.Text;

namespace CoinExApiAccess.Entities
{
    public class Withdrawal
    {
        public int coin_withdrawal_id { get; set; }
        public long create_time { get; set; }
        public decimal amount { get; set; }
        public decimal actual_amount { get; set; }
        public string tx_id { get; set; }
        public string coin_address { get; set; }
        public decimal tx_fee { get; set; }
        public int confirmations { get; set; }
        public string coin_type { get; set; }
        public string status { get; set; }
    }
}
