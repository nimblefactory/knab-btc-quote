using Knab.Btc.Quote.Core.Model;
using MediatR;

namespace Knab.Btc.Quote.Core.Messages;

public class GetCryptoQuoteRequest : IRequest<GetCryptoQuoteResponse>
{
    public string CryptoId { get; set; } = string.Empty;
    public List<string> CurrencyCodeList { get; set; } = [];
}
