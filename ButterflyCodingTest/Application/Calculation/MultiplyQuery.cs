using MediatR;
using System.Numerics;

namespace ButterflyCodingTest.Application.Calculation;

public record MultiplyQuery(BigInteger Left, BigInteger Right) : IRequest<BigInteger>;

public class MultiplyQueryHandler : IRequestHandler<MultiplyQuery, BigInteger>
{
	public Task<BigInteger> Handle(MultiplyQuery query, CancellationToken _cancellationToken)
		=> Task.FromResult(query.Left * query.Right);
}
