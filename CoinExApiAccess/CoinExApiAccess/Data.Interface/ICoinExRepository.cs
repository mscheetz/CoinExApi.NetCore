using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoinExApiAccess.Data.Interface
{
    public interface ICoinExRepository
    {
        Task<string[]> GetMarketList();
    }
}
