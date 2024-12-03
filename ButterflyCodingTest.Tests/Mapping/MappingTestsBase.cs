using AutoMapper;
using ButterflyCodingTest.Application.Shared;

namespace ButterflyCodingTest.Tests.Mapping;

public class MappingTestsBase
{
	protected readonly IMapper _mapper;

	public MappingTestsBase()
	{
		_mapper = new MapperConfiguration(config => config.AddProfile(new MappingProfile()))
			.CreateMapper();
	}
}