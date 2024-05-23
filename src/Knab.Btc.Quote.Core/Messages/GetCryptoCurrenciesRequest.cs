using Knab.Btc.Quote.Core.Model;
using MediatR;

namespace Knab.Btc.Quote.Core.Messages;

public class GetCryptoCurrenciesRequest : IRequest<GetCryptoCurrenciesResponse>
{
}
