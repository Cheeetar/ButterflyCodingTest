using FluentValidation;
using System.Numerics;

namespace ButterflyCodingTest.Controllers.Models;

public record PostAdd
(
	string Left,
	string Right
);

public class PostAddValidator : AbstractValidator<PostAdd>
{
	public PostAddValidator()
	{
		RuleFor(postAdd => postAdd.Left)
			.Must(left => BigInteger.TryParse(left, out _))
			.WithMessage("Left side of equation was not a valid integer.");
		RuleFor(postAdd => postAdd.Right)
			.Must(right => BigInteger.TryParse(right, out _))
			.WithMessage("Right side of equation was not a valid integer.");
	}
}