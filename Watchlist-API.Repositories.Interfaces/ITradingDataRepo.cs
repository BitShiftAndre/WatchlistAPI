using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchlist_API.Models;

namespace Watchlist_API.Repositories.Interfaces
{
    public interface ITradingDataRepo
    {
        Task<IEnumerable<StockData>> GetDefaultSymbols();
        Task<StockData> GetStock(string symbol);
    } 
}
