using Knab.Btc.Quote.Core.Messages;
using Knab.Btc.Quote.Core.Model;
using Knab.Btc.Quote.Core.Ports;
using MediatR;

namespace Knab.Btc.Quote.Core;

public class CryptoCurrencyService : ICryptoCurrencyService
{
    private readonly IMediator _mediator;

    public CryptoCurrencyService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<GetCryptoCurrenciesResponse> GetCurrencies(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetCryptoCurrenciesRequest(), cancellationToken);

        return result;
    }
}
