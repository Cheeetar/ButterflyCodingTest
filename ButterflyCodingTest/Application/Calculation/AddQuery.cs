using MediatR;
using System.Numerics;

namespace ButterflyCodingTest.Application.Calculation;

public record AddQuery(BigInteger Left, BigInteger Right) : IRequest<BigInteger>;

public class AddQueryHandler : IRequestHandler<AddQuery, BigInteger>
{
	public Task<BigInteger> Handle(AddQuery query, CancellationToken _cancellationToken)
		=> Task.FromResult(query.Left + query.Right);
}
