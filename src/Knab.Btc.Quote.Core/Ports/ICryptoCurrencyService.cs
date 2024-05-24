using Knab.Btc.Quote.Core.Model;

namespace Knab.Btc.Quote.Core.Ports;

public interface ICryptoCurrencyService
{
    Task<GetCryptoCurrenciesResponse> GetCurrencies(CancellationToken cancellationToken);
}
