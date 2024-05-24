using Knab.Btc.Quote.Core.Messages;
using Knab.Btc.Quote.Core.Model;
using Knab.Btc.Quote.Core.Ports;
using MediatR;

namespace Knab.Btc.Quote.Core;

public class CryptoQuoteService : ICryptoQuoteService
{
    private readonly IMediator _mediator;

    public CryptoQuoteService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<GetCryptoQuoteResponse> GetQuote(string cryptoId, IEnumerable<string> currencyCodes, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetCryptoQuoteRequest
        {
            CryptoId = cryptoId,
            CurrencyCodeList = currencyCodes.ToList()
        }, cancellationToken);

        return result;
    }
}
