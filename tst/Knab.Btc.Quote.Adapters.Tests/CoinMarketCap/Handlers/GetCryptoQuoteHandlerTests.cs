using Knab.Btc.Quote.Adapters.CoinMarketCap;
using Knab.Btc.Quote.Adapters.CoinMarketCap.Handlers;
using Knab.Btc.Quote.Core.Messages;

namespace Knab.Btc.Quote.Adapters.Tests.CoinMarketCap.Handlers;

public class GetCryptoQuoteHandlerTests
{
    [Theory]
    [AutoData]
    public async Task Handle_Returns_Empty_GetCryptoQuoteResponse(CryptoCurrencyApiSettings settings, GetCryptoQuoteRequest request)
    {
        // Arrange
        settings.BaseUrl = $"https://{settings.BaseUrl}";

        var httpTest = new HttpTest();
        httpTest
            .ForCallsTo("*/v2/cryptocurrency/quotes/latest")
            .RespondWith("", 200);

        var sut = new GetCryptoQuoteHandler(settings);

        // Act
        var result = await sut.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.CryptoQuotes.Should().NotBeNull().And.BeEmpty();
    }

    [Theory]
    [AutoData]
    public async Task Handle_Returns_GetCryptoQuoteResponse(CryptoCurrencyApiSettings settings)
    {
        // Arrange
        settings.BaseUrl = $"https://{settings.BaseUrl}";

        var json = File.ReadAllText("data/GetCryptoQuoteHandler_BTC_USD.json");

        var request = new GetCryptoQuoteRequest() { CryptoId = "1", CurrencyCodeList = ["USD"] };

        var httpTest = new HttpTest();
        httpTest
            .ForCallsTo("*/v2/cryptocurrency/quotes/latest")
            .WithHeader("X-CMC_PRO_API_KEY", settings.ApiKey)
            .WithQueryParam("id", request.CryptoId)
            .RespondWith(json, 200);

        var sut = new GetCryptoQuoteHandler(settings);

        // Act
        var result = await sut.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.CryptoId.Should().Be("1");
        result.CryptoSymbol.Should().Be("BTC");
        result.CryptoName.Should().Be("Bitcoin");
        result.CryptoQuotes.Should().NotBeNull().And.HaveCount(1);
    }
}
