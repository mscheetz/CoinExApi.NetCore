using System;
using System.Collections.Generic;
using System.Text;

namespace CoinExApiAccess.Entities
{
    public class MiningDifficulty
    {
        public decimal difficulty { get; set; }
        public decimal prediction { get; set; }
        public long update_time { get; set; }
    }
}
