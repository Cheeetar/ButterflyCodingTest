using ButterflyCodingTest.Application.Calculation;
using FluentAssertions;
using System.Numerics;

namespace ButterflyCodingTest.Tests.Application.Calculation;

public class DivideAddQueryHandlerTests
{
	private readonly DivideQueryHandler _handler = new();

	[Theory]
	[InlineData(6, 2, 3)]
	[InlineData(int.MinValue, int.MinValue, 1)]
	public async Task GivenDivideQuery_WhenProcessed_ReturnsResultOfTwoIntegersAddedTogether(long left, long right, long expectedResult)
	{
		// Arrange
		var query = new DivideQuery(new BigInteger(left), new BigInteger(right));

		// Act
		var result = await _handler.Handle(query, CancellationToken.None);

		// Assert
		(result == expectedResult).Should().BeTrue();
	}
}