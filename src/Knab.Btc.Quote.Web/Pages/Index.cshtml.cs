using Knab.Btc.Quote.Core.Ports;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Knab.Btc.Quote.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ICryptoCurrencyService _cryptoCurrencyService;

    public List<SelectListItem> CryptoCurrencies { get; set; } = [];

    public IndexModel(ICryptoCurrencyService cryptoCurrencyService)
    {
        _cryptoCurrencyService = cryptoCurrencyService;
    }

    public async Task OnGet(CancellationToken cancellationToken)
    {
        var currencies = (await _cryptoCurrencyService.GetCurrencies(cancellationToken))
            .CryptoCurrencies
            .Select(x => new SelectListItem(x.Value, x.Key))
            .ToList();

        CryptoCurrencies = currencies;
    }
}
