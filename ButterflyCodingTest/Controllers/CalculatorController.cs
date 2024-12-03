using AutoMapper;
using ButterflyCodingTest.Application.Calculation;
using ButterflyCodingTest.Controllers.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ButterflyCodingTest.Controllers;

[ApiController]
[Route("calculator")]
public class CalculatorController(IMediator mediator, IMapper mapper) : ControllerBase
{
	private readonly IMediator _mediator = mediator;
	private readonly IMapper _mapper = mapper;

	/// <summary>
	/// Adds two integers together.
	/// </summary>
	[HttpPost("add")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<string>> Add([FromBody]PostAdd request, CancellationToken cancellationToken)
	{
		var query = _mapper.Map<AddQuery>(request);
		var result = await _mediator.Send(query, cancellationToken);
		return result.ToString();
	}

	/// <summary>
	/// Subtracts the right integer from the left integer.
	/// </summary>
	[HttpPost("subtract")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<string>> Subtract([FromBody] PostSubtract request, CancellationToken cancellationToken)
	{
		var query = _mapper.Map<SubtractQuery>(request);
		var result = await _mediator.Send(query, cancellationToken);
		return result.ToString();
	}

	/// <summary>
	/// Divides the left integer by the right integer and returns the integer quotient.
	/// </summary>
	[HttpPost("divide")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<string>> Divide([FromBody] PostDivide request, CancellationToken cancellationToken)
	{
		var query = _mapper.Map<DivideQuery>(request);
		var result = await _mediator.Send(query, cancellationToken);
		return result.ToString();
	}

	/// <summary>
	/// Multiplies two integers.
	/// </summary>
	[HttpPost("multiply")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<string>> Multiply([FromBody] PostMultiply request, CancellationToken cancellationToken)
	{
		var query = _mapper.Map<MultiplyQuery>(request);
		var result = await _mediator.Send(query, cancellationToken);
		return result.ToString();
	}
}