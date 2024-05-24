using Knab.Btc.Quote.Core.Model;

namespace Knab.Btc.Quote.Core.Ports;

public interface ICryptoQuoteService
{
    Task<GetCryptoQuoteResponse> GetQuote(string cryptoId, IEnumerable<string> currencyCodes, CancellationToken cancellationToken);
}
