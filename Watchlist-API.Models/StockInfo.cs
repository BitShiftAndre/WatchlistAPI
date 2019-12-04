using System;
using Newtonsoft.Json;

namespace Watchlist_API.Models
{
  public class StockInfo
  {
    public int Symbols_Requested { get; set; }
    public int Symbols_Returned { get; set; }
    public StockData[] Data { get; set; }
  }

  public class StockData
  {
    public string Symbol { get; set; }
    public string Name { get; set; }
    public string Currency { get; set; }
    public decimal Price { get; set; }
    public decimal Price_Open { get; set; }
    public decimal Day_High { get; set; }
    public decimal Day_Low { get; set; }

    [JsonProperty(PropertyName = "52_week_high")]
    public decimal FiftyTwoWeekHigh { get; set; }

    [JsonProperty(PropertyName = "52_week_low")]
    public decimal FiftyTwoWeekLow { get; set; }
    public decimal Day_Change { get; set; }
    public decimal Change_Pct { get; set; }
    public decimal Close_Yesterday { get; set; }
    public long Market_Cap { get; set; }
    public long Volume { get; set; }
    public long Volume_Avg { get; set; }
    public long Shares { get; set; }
    public string Stock_Exchange_Long { get; set; }
    public string Stock_Exxchange_Short { get; set; }
    public string Timezone { get; set; }
    public string Timezone_Name { get; set; }
    public int Gmt_Offset { get; set; }
    public DateTime Last_Trade_Time { get; set; }

  }
}
