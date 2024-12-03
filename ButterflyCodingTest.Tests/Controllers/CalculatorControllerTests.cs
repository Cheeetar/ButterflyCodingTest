using AutoMapper;
using ButterflyCodingTest.Application.Calculation;
using ButterflyCodingTest.Application.Shared;
using ButterflyCodingTest.Controllers;
using ButterflyCodingTest.Controllers.Models;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Numerics;

namespace ButterflyCodingTest.Tests.Controllers;

public class CalculatorControllerTests
{
    private readonly Mock<IMediator> _mediator = new();
    private readonly CalculatorController _controller;

    public CalculatorControllerTests()
    {
		var mapper = new MapperConfiguration(config => config.AddProfile(new MappingProfile()))
			.CreateMapper();
        _controller = new(_mediator.Object, mapper);
    }

	[Fact]
	public async Task GivenPostAddRequest_WhenProcessed_SendsAddQueryAndReturnsResponse()
	{
		// Arrange
		var request = new PostAdd("6", "2");
		var calculation = new BigInteger(8);
		_mediator.Setup(mediator => mediator.Send(It.IsAny<AddQuery>(), CancellationToken.None)).ReturnsAsync(calculation);

		// Act
		var result = await _controller.Add(request, CancellationToken.None);

		// Assert
		_mediator.Verify(mediator => mediator.Send(It.Is<AddQuery>(query => query.Left == 6 && query.Right == 2), CancellationToken.None), Times.Once);
		result.Should().BeOfType<ActionResult<string>>()
			.Which.Value.Should().Be(calculation.ToString());
	}

	[Fact]
	public async Task GivenPostSubtractRequest_WhenProcessed_SendsSubtractQueryAndReturnsResponse()
	{
		// Arrange
		var request = new PostSubtract("6", "2");
		var calculation = new BigInteger(8);
		_mediator.Setup(mediator => mediator.Send(It.IsAny<SubtractQuery>(), CancellationToken.None)).ReturnsAsync(calculation);

		// Act
		var result = await _controller.Subtract(request, CancellationToken.None);

		// Assert
		_mediator.Verify(mediator => mediator.Send(It.Is<SubtractQuery>(query => query.Left == 6 && query.Right == 2), CancellationToken.None), Times.Once);
		result.Should().BeOfType<ActionResult<string>>()
			.Which.Value.Should().Be(calculation.ToString());
	}

	[Fact]
	public async Task GivenPostDivideRequest_WhenProcessed_SendsDivideQueryAndReturnsResponse()
	{
		// Arrange
		var request = new PostDivide("6", "2");
		var calculation = new BigInteger(8);
		_mediator.Setup(mediator => mediator.Send(It.IsAny<DivideQuery>(), CancellationToken.None)).ReturnsAsync(calculation);

		// Act
		var result = await _controller.Divide(request, CancellationToken.None);

		// Assert
		_mediator.Verify(mediator => mediator.Send(It.Is<DivideQuery>(query => query.Left == 6 && query.Right == 2), CancellationToken.None), Times.Once);
		result.Should().BeOfType<ActionResult<string>>()
			.Which.Value.Should().Be(calculation.ToString());
	}

	[Fact]
	public async Task GivenPostMultiplyRequest_WhenProcessed_SendsMultiplyQueryAndReturnsResponse()
	{
		// Arrange
		var request = new PostMultiply("6", "2");
		var calculation = new BigInteger(8);
		_mediator.Setup(mediator => mediator.Send(It.IsAny<MultiplyQuery>(), CancellationToken.None)).ReturnsAsync(calculation);

		// Act
		var result = await _controller.Multiply(request, CancellationToken.None);

		// Assert
		_mediator.Verify(mediator => mediator.Send(It.Is<MultiplyQuery>(query => query.Left == 6 && query.Right == 2), CancellationToken.None), Times.Once);
		result.Should().BeOfType<ActionResult<string>>()
			.Which.Value.Should().Be(calculation.ToString());
	}
}