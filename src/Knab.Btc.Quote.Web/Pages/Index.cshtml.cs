using Knab.Btc.Quote.Core.Ports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Knab.Btc.Quote.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ICryptoQuoteService _cryptoQuoteService;

    public List<SelectListItem> CryptoCurrencies { get; set; } = [];

    public IndexModel(ICryptoQuoteService cryptoQuoteService)
    {
        _cryptoQuoteService = cryptoQuoteService;
    }

    public async Task OnGet(CancellationToken cancellationToken)
    {
        CryptoCurrencies = (await _cryptoQuoteService.GetCurrencies(cancellationToken))
            .CryptoCurrencies
            .Select(x => new SelectListItem(x.Value, x.Key))
            .ToList();
    }
}
