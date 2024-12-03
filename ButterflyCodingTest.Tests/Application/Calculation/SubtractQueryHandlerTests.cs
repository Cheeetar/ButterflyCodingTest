using ButterflyCodingTest.Application.Calculation;
using FluentAssertions;
using System.Numerics;

namespace ButterflyCodingTest.Tests.Application.Calculation;

public class SubtractQueryHandlerTests
{
	private readonly SubtractQueryHandler _handler = new();

	[Theory]
	[InlineData(6, 2, 4)]
	[InlineData(int.MinValue, int.MinValue, 0)]
	public async Task GivenSubtractQuery_WhenProcessed_ReturnsResultOfLeftBeingSubtractedFromRight(long left, long right, long expectedResult)
	{
		// Arrange
		var query = new SubtractQuery(new BigInteger(left), new BigInteger(right));

		// Act
		var result = await _handler.Handle(query, CancellationToken.None);

		// Assert
		(result == expectedResult).Should().BeTrue();
	}
}