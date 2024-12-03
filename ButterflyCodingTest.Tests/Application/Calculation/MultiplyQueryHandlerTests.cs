using ButterflyCodingTest.Application.Calculation;
using FluentAssertions;
using System.Numerics;

namespace ButterflyCodingTest.Tests.Application.Calculation;

public class MultiplyQueryHandlerTests
{
	private readonly MultiplyQueryHandler _handler = new();

	[Theory]
	[InlineData(6, 2, 12)]
	[InlineData(int.MinValue, int.MinValue, 4611686018427387904L)]
	public async Task GivenMultiplyQuery_WhenProcessed_ReturnsResultOfTwoIntegersMultipliedTogether(long left, long right, long expectedResult)
	{
		// Arrange
		var query = new MultiplyQuery(new BigInteger(left), new BigInteger(right));

		// Act
		var result = await _handler.Handle(query, CancellationToken.None);

		// Assert
		(result == expectedResult).Should().BeTrue();
	}
}