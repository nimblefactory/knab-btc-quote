namespace Knab.Btc.Quote.Adapters.CoinMarketCap.Models;

public class CryptoCurrenciesResultItem
{
    public int Id { get; set; }
    public string Name { get; set; } = "Unknown";
}

public class CryptoCurrenciesResult
{
    public CryptoCurrenciesResultItem[] Data { get; set; } = [];
}
