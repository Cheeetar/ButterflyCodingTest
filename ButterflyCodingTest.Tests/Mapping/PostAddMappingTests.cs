using ButterflyCodingTest.Application.Calculation;
using ButterflyCodingTest.Controllers.Models;
using FluentAssertions;
using System.Numerics;

namespace ButterflyCodingTest.Tests.Mapping;

public class PostAddMappingTests : MappingTestsBase
{
	[Fact]
	public void GivenPostAdd_WhenMappedToAddQuery_AllFieldsSet()
	{
		// Arrange
		var postAdd = new PostAdd("6", "2");

		// Act
		var addQuery = _mapper.Map<AddQuery>(postAdd);

		// Assert
		addQuery.Left.Should().Be(new BigInteger(6));
		addQuery.Right.Should().Be(new BigInteger(2));
	}
}