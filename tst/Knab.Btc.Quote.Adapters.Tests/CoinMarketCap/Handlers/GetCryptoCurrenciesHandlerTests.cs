using Knab.Btc.Quote.Adapters.CoinMarketCap;
using Knab.Btc.Quote.Adapters.CoinMarketCap.Handlers;
using Knab.Btc.Quote.Core.Messages;

namespace Knab.Btc.Quote.Adapters.Tests.CoinMarketCap.Handlers;

public class GetCryptoCurrenciesHandlerTests
{
    [Theory]
    [AutoData]
    public async Task Handle_Returns_Empty_GetCryptoCurrenciesResponse(CryptoCurrencyApiSettings settings, GetCryptoCurrenciesRequest request)
    {
        // Arrange
        settings.BaseUrl = $"https://{settings.BaseUrl}";

        var httpTest = new HttpTest();
        httpTest
            .ForCallsTo("*/v1/cryptocurrency/map")
            .RespondWith("", 200);

        var sut = new GetCryptoCurrenciesHandler(settings);

        // Act
        var result = await sut.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.CryptoCurrencies.Should().NotBeNull().And.BeEmpty();
    }

    [Theory]
    [AutoData]
    public async Task Handle_Returns_GetCryptoCurrenciesResponse(CryptoCurrencyApiSettings settings, GetCryptoCurrenciesRequest request)
    {
        // Arrange
        settings.BaseUrl = $"https://{settings.BaseUrl}";

        var json = File.ReadAllText("data/GetCryptoCurrenciesHandler_10.json");

        var httpTest = new HttpTest();
        httpTest
            .ForCallsTo("*/v1/cryptocurrency/map")
            .WithHeader("X-CMC_PRO_API_KEY", settings.ApiKey)
            .WithQueryParam("limit", "10")
            .WithQueryParam("sort", "cmc_rank")
            .RespondWith(json, 200);

        var sut = new GetCryptoCurrenciesHandler(settings);

        // Act
        var result = await sut.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.CryptoCurrencies.Should().NotBeNull().And.HaveCount(10);
    }
}