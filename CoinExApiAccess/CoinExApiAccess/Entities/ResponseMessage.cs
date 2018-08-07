using System;
using System.Collections.Generic;
using System.Text;

namespace CoinExApiAccess.Entities
{
    public class ResponseMessage<T>
    {
        public int code { get; set; }
        public T data { get; set; }
        public string message { get; set; }
    }
}
