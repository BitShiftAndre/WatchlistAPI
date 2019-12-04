using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Watchlist_API.Config;
using Watchlist_API.Models;
using Watchlist_API.Repositories.Interfaces;

namespace Watchlist_API.Repositories
{
  public class TradingDataRepo : ITradingDataRepo
  {
    private WorldTradingData worldTradingData;
    private HttpClient client = new HttpClient();
    public TradingDataRepo(IOptions<WorldTradingData> worldTradingData)
    {
      this.worldTradingData = worldTradingData.Value;
    }
    public async Task<IEnumerable<StockData>> GetDefaultSymbols()
    {
      client.BaseAddress = new Uri("https://api.worldtradingdata.com/api/v1/");
      var response = await client.GetAsync("stock?symbol=SNAP,AAPL,AMZN,GOOGL,TSLA&api_token=Q7YDKiv7Riw1TtaXkxyotfyvhONHUwsvToYaD7igmIugXWkklhCKFALy9DPy");
      if (response.IsSuccessStatusCode)
      {
        var result = await response.Content.ReadAsAsync<StockInfo>();
        return result.Data;
      }
      throw new Exception("Something Broke, Bruv!");
    }

    public async Task<StockData> GetStock(string symbol)
    {
      client.BaseAddress = new Uri("https://api.worldtradingdata.com/api/v1/");
      var response = await client.GetAsync($"stock?symbol={symbol.Trim().ToUpper()}&api_token=Q7YDKiv7Riw1TtaXkxyotfyvhONHUwsvToYaD7igmIugXWkklhCKFALy9DPy");
      if (response.IsSuccessStatusCode)
      {
        var result = await response.Content.ReadAsAsync<StockInfo>();
        return result.Data.FirstOrDefault();
      }
      throw new Exception("Something Broke, Bruv!");
    }
  }
}
