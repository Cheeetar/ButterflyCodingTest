using FluentValidation;
using System.Numerics;

namespace ButterflyCodingTest.Controllers.Models;

public record PostDivide
(
	string Left,
	string Right
);

public class PostDivideValidator : AbstractValidator<PostDivide>
{
	public PostDivideValidator()
	{
		RuleFor(postAdd => postAdd.Left)
			.Must(left => BigInteger.TryParse(left, out _))
			.WithMessage("Left side of equation was not a valid integer.");

		RuleFor(postAdd => postAdd.Right)
			.Must(right => BigInteger.TryParse(right, out var rightNumber) && rightNumber != BigInteger.Zero)
			.WithMessage("Right side of equation was not a valid integer, or was zero.");
	}
}
