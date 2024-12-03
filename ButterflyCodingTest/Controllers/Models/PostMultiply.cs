using FluentValidation;
using System.Numerics;

namespace ButterflyCodingTest.Controllers.Models;

public record PostMultiply
(
	string Left,
	string Right
);

public class PostMultiplyValidator : AbstractValidator<PostMultiply>
{
	public PostMultiplyValidator()
	{
		RuleFor(postAdd => postAdd.Left)
			.Must(left => BigInteger.TryParse(left, out _))
			.WithMessage("Left side of equation was not a valid integer.");

		RuleFor(postAdd => postAdd.Right)
			.Must(right => BigInteger.TryParse(right, out var rightNumber))
			.WithMessage("Right side of equation was not a valid integer.");
	}
}