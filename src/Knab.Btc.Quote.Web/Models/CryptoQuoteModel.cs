namespace Knab.Btc.Quote.Web.Models;

public class CryptoQuoteModel
{
    public string CryptoSymbol { get; set; } = string.Empty;
    public string CurrencySymbol { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
