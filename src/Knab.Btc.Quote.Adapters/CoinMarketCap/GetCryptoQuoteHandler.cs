using Flurl;
using Flurl.Http;
using Knab.Btc.Quote.Adapters.CoinMarketCap.Models;
using Knab.Btc.Quote.Core.Messages;
using Knab.Btc.Quote.Core.Model;
using MediatR;

namespace Knab.Btc.Quote.Adapters.CoinMarketCap;

public class GetCryptoQuoteHandler : IRequestHandler<GetCryptoQuoteRequest, GetCryptoQuoteResponse>
{
    private readonly CryptoCurrencyApiSettings _settings;

    public GetCryptoQuoteHandler(CryptoCurrencyApiSettings settings)
    {
        _settings = settings;
    }

    public async Task<GetCryptoQuoteResponse> Handle(GetCryptoQuoteRequest request, CancellationToken cancellationToken)
    {
        var taskList = request.CurrencyCodeList
            .Select(x =>
            {
                return _settings
                    .BaseUrl
                    .AppendPathSegment("/v2/cryptocurrency/quotes/latest")
                    .WithHeader("X-CMC_PRO_API_KEY", _settings.ApiKey)
                    .WithHeader("Accepts", "application/json")
                    .AppendQueryParam("id", request.CryptoId)
                    .AppendQueryParam("convert", x)
                    .GetJsonAsync<QuoteResult>(cancellationToken: cancellationToken);
            })
            .ToList();

        var results = await Task.WhenAll(taskList);

        if (results.Length == 0)
        {
            return new GetCryptoQuoteResponse();
        }

        var cryptoSymbol = results.First().Data[request.CryptoId].Symbol;
        var cryptoName = results.First().Data[request.CryptoId].Name;

        return new GetCryptoQuoteResponse
        {
            CryptoId = request.CryptoId,
            CryptoSymbol = cryptoSymbol,
            CryptoName = cryptoName,
            CryptoQuotes = results
            .SelectMany(x => x.Data[request.CryptoId].Quotes)
            .Select(x => new CryptoQuoteItem
            {
                CurrencySymbol = x.Key,
                Price = x.Value.Price
            })
            .ToList()
        };
    }
}
