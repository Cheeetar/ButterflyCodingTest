using ButterflyCodingTest.Application.Calculation;
using ButterflyCodingTest.Controllers.Models;
using FluentAssertions;
using System.Numerics;

namespace ButterflyCodingTest.Tests.Mapping;

public class PostSubtractMappingTests : MappingTestsBase
{
	[Fact]
	public void GivenPostSubtract_WhenMappedToSubtractQuery_AllFieldsSet()
	{
		// Arrange
		var postSubtract = new PostSubtract("6", "2");

		// Act
		var subtractQuery = _mapper.Map<SubtractQuery>(postSubtract);

		// Assert
		subtractQuery.Left.Should().Be(new BigInteger(6));
		subtractQuery.Right.Should().Be(new BigInteger(2));
	}
}