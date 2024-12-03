using MediatR;
using System.Numerics;

namespace ButterflyCodingTest.Application.Calculation;

public record SubtractQuery(BigInteger Left, BigInteger Right) : IRequest<BigInteger>;

public class SubtractQueryHandler : IRequestHandler<SubtractQuery, BigInteger>
{
	public Task<BigInteger> Handle(SubtractQuery query, CancellationToken _cancellationToken)
		=> Task.FromResult(query.Left - query.Right);
}
