using Knab.Btc.Quote.Core.Messages;
using Knab.Btc.Quote.Core.Model;
using MediatR;

namespace Knab.Btc.Quote.Core.Tests;

public class CryptoQuoteServiceTests
{
    [Theory]
    [AutoData]
    public async Task GetCurrencies_Returns_GetCryptoQuoteResponse(string cryptoId, string[] currencyCodes)
    {
        // Arrange
        var mediatorMock = Substitute.For<IMediator>();
        mediatorMock
            .Send(Arg.Is<GetCryptoQuoteRequest>(x =>
                x.CryptoId == cryptoId &&
                x.CurrencyCodeList.All(currencyCodes.Contains)
             ), Arg.Any<CancellationToken>())
            .Returns(new GetCryptoQuoteResponse());

        var sut = new CryptoQuoteService(mediatorMock);

        // Act
        var result = await sut.GetQuote(cryptoId, currencyCodes, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
    }
}