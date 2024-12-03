using AutoMapper;
using ButterflyCodingTest.Application.Calculation;
using ButterflyCodingTest.Controllers.Models;
using System.Numerics;

namespace ButterflyCodingTest.Application.Shared;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<PostAdd, AddQuery>()
			.ForCtorParam(nameof(AddQuery.Left),
				options => options.MapFrom(source => BigInteger.Parse(source.Left)))
			.ForCtorParam(nameof(AddQuery.Right),
				options => options.MapFrom(source => BigInteger.Parse(source.Right)));

		CreateMap<PostSubtract, SubtractQuery>()
			.ForCtorParam(nameof(SubtractQuery.Left),
				options => options.MapFrom(source => BigInteger.Parse(source.Left)))
			.ForCtorParam(nameof(SubtractQuery.Right),
				options => options.MapFrom(source => BigInteger.Parse(source.Right)));

		CreateMap<PostDivide, DivideQuery>()
			.ForCtorParam(nameof(DivideQuery.Left),
				options => options.MapFrom(source => BigInteger.Parse(source.Left)))
			.ForCtorParam(nameof(DivideQuery.Right),
				options => options.MapFrom(source => BigInteger.Parse(source.Right)));

		CreateMap<PostMultiply, MultiplyQuery>()
			.ForCtorParam(nameof(MultiplyQuery.Left),
				options => options.MapFrom(source => BigInteger.Parse(source.Left)))
			.ForCtorParam(nameof(MultiplyQuery.Right),
				options => options.MapFrom(source => BigInteger.Parse(source.Right)));
	}
}
