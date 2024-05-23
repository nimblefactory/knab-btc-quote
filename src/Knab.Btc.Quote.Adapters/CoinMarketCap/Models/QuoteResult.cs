using System.Text.Json.Serialization;

namespace Knab.Btc.Quote.Adapters.CoinMarketCap.Models;

public class QuoteItem
{
    public decimal Price { get; set; }
}

public class QuoteResultItem
{
    public string Name { get; set; } = "Unknown";
    public string Symbol { get; set; } = "Unknown";
    [JsonPropertyName("quote")]
    public Dictionary<string, QuoteItem> Quotes { get; set; } = [];
}

public class QuoteResult
{
    public Dictionary<string, QuoteResultItem> Data { get; set; } = [];
}
