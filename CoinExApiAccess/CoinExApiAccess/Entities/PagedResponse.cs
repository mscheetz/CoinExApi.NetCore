using System;
using System.Collections.Generic;
using System.Text;

namespace CoinExApiAccess.Entities
{
    public class PagedResponse<T>
    {
        public int count { get; set; }
        public int curr_page { get; set; }
        public T data { get; set; }
        public bool has_next { get; set; }
    }
}
