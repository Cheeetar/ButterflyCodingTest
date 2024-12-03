using ButterflyCodingTest.Application.Calculation;
using FluentAssertions;
using System.Numerics;

namespace ButterflyCodingTest.Tests.Application.Calculation;

public class AddQueryHandlerTests
{
	private readonly AddQueryHandler _handler = new();

	[Theory]
	[InlineData(6, 2, 8)]
	[InlineData(int.MinValue, int.MinValue, -4294967296D)]
	public async Task GivenAddQuery_WhenProcessed_ReturnsResultOfLeftBeingDividedByRight(long left, long right, long expectedResult)
	{
		// Arrange
		var query = new AddQuery(new BigInteger(left), new BigInteger(right));

		// Act
		var result = await _handler.Handle(query, CancellationToken.None);

		// Assert
		(result == expectedResult).Should().BeTrue();
	}
}