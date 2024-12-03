using FluentValidation;
using System.Numerics;

namespace ButterflyCodingTest.Controllers.Models;

public record PostSubtract
(
	string Left,
	string Right
);

public class PostSubtractValidator : AbstractValidator<PostSubtract>
{
	public PostSubtractValidator()
	{
		RuleFor(postAdd => postAdd.Left)
			.Must(left => BigInteger.TryParse(left, out _))
			.WithMessage("Left side of equation was not a valid integer.");

		RuleFor(postAdd => postAdd.Right)
			.Must(right => BigInteger.TryParse(right, out var rightNumber))
			.WithMessage("Right side of equation was not a valid integer.");
	}
}
