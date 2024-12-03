using MediatR;
using System.Numerics;

namespace ButterflyCodingTest.Application.Calculation;

public record DivideQuery(BigInteger Left, BigInteger Right) : IRequest<BigInteger>;

public class DivideQueryHandler : IRequestHandler<DivideQuery, BigInteger>
{
	public Task<BigInteger> Handle(DivideQuery query, CancellationToken _cancellationToken)
		=> Task.FromResult(query.Left / query.Right);
}
