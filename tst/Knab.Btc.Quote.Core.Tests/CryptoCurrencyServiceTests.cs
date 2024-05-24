using Knab.Btc.Quote.Core.Messages;
using Knab.Btc.Quote.Core.Model;
using MediatR;

namespace Knab.Btc.Quote.Core.Tests;

public class CryptoCurrencyServiceTests
{
    [Fact]
    public async Task GetCurrencies_Returns_GetCryptoCurrenciesResponse()
    {
        // Arrange
        var mediatorMock = Substitute.For<IMediator>();
        mediatorMock
            .Send(Arg.Any<GetCryptoCurrenciesRequest>(), Arg.Any<CancellationToken>())
            .Returns(new GetCryptoCurrenciesResponse());

        var sut = new CryptoCurrencyService(mediatorMock);

        // Act
        var result = await sut.GetCurrencies(CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
    }
}