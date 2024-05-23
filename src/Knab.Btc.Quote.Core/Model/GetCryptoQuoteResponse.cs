namespace Knab.Btc.Quote.Core.Model;

public class CryptoQuoteItem
{
    public string CurrencySymbol { get; set; } = "Unknown";
    public decimal Price { get; set; }
}

public class GetCryptoQuoteResponse
{
    public string CryptoId { get; set; } = "Unknown";
    public string CryptoSymbol { get; set; } = "Unknown";
    public string CryptoName { get; set; } = "Unknown";
    public List<CryptoQuoteItem> CryptoQuotes { get; set; } = [];
}