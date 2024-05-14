using Lynkco.Warranty.WebAPI.Application.Common.Mapper.Contracts;

namespace Lynkco.Warranty.WebAPI.Application.Common.Mapper
{
	public abstract class MapperBase<TSource, TDestination> : IMapper<TSource, TDestination>
	{
		public abstract TDestination Map(TSource source);

		public IEnumerable<TDestination> MapCollection(IEnumerable<TSource> source)
			=> source.Select(Map);
	}
}
