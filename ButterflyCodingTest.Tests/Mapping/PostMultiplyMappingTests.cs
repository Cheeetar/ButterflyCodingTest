using ButterflyCodingTest.Application.Calculation;
using ButterflyCodingTest.Controllers.Models;
using FluentAssertions;
using System.Numerics;

namespace ButterflyCodingTest.Tests.Mapping;

public class PostMultiplyMappingTests : MappingTestsBase
{
	[Fact]
	public void GivenPostMultiply_WhenMappedToMultiplyQuery_AllFieldsSet()
	{
		// Arrange
		var postMultiply = new PostMultiply("6", "2");

		// Act
		var multiplyQuery = _mapper.Map<MultiplyQuery>(postMultiply);

		// Assert
		multiplyQuery.Left.Should().Be(new BigInteger(6));
		multiplyQuery.Right.Should().Be(new BigInteger(2));
	}
}