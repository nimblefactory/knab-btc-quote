using Knab.Btc.Quote.Core.Ports;
using Knab.Btc.Quote.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Knab.Btc.Quote.Web.Pages;

public class QuoteModel : PageModel
{
    private readonly ICryptoQuoteService _cryptoQuoteService;

    public string CryptoName { get; set; } = "Unknown";

    public List<CryptoQuoteModel> Quotes { get; set; } = [];

    public QuoteModel(ICryptoQuoteService cryptoQuoteService)
    {
        _cryptoQuoteService = cryptoQuoteService;
    }

    public async Task OnGet(string cryptoId, CancellationToken cancellationToken)
    {
        var result = await _cryptoQuoteService.GetQuote(cryptoId, Constants.CurrenciesToQuote, cancellationToken);

        if (result == null || result.CryptoQuotes.Count == 0)
        {
            return;
        }

        CryptoName = result.CryptoName;

        Quotes = result.CryptoQuotes
            .Select(x => new CryptoQuoteModel
            {
                CryptoSymbol = result.CryptoSymbol,
                CurrencySymbol = x.CurrencySymbol,
                Price = x.Price
            })
            .ToList();
    }
}
