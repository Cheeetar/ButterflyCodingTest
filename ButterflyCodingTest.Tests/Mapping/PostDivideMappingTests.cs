using ButterflyCodingTest.Application.Calculation;
using ButterflyCodingTest.Controllers.Models;
using FluentAssertions;
using System.Numerics;

namespace ButterflyCodingTest.Tests.Mapping;

public class PostDivideMappingTests : MappingTestsBase
{
	[Fact]
	public void GivenPostDivide_WhenMappedToDivideQuery_AllFieldsSet()
	{
		// Arrange
		var postDivide = new PostDivide("6", "2");

		// Act
		var divideQuery = _mapper.Map<DivideQuery>(postDivide);

		// Assert
		divideQuery.Left.Should().Be(new BigInteger(6));
		divideQuery.Right.Should().Be(new BigInteger(2));
	}
}