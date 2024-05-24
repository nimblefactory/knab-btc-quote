using Flurl;
using Flurl.Http;
using Knab.Btc.Quote.Adapters.CoinMarketCap.Models;
using Knab.Btc.Quote.Core.Messages;
using Knab.Btc.Quote.Core.Model;
using MediatR;

namespace Knab.Btc.Quote.Adapters.CoinMarketCap.Handlers;

public class GetCryptoCurrenciesHandler : IRequestHandler<GetCryptoCurrenciesRequest, GetCryptoCurrenciesResponse>
{
    private readonly CryptoCurrencyApiSettings _settings;

    public GetCryptoCurrenciesHandler(CryptoCurrencyApiSettings settings)
    {
        _settings = settings;
    }

    public async Task<GetCryptoCurrenciesResponse> Handle(GetCryptoCurrenciesRequest request, CancellationToken cancellationToken)
    {
        var result = await _settings
            .BaseUrl
            .AppendPathSegment("/v1/cryptocurrency/map")
            .WithHeader("X-CMC_PRO_API_KEY", _settings.ApiKey)
            .SetQueryParam("limit", "10")
            .SetQueryParam("sort", "cmc_rank")
            .GetJsonAsync<CryptoCurrenciesResult>(cancellationToken: cancellationToken);

        if (result == null)
        {
            return new GetCryptoCurrenciesResponse();
        }

        return new GetCryptoCurrenciesResponse
        {
            CryptoCurrencies = result.Data.ToDictionary(x => x.Id.ToString(), x => x.Name)
        };
    }
}
