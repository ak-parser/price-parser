namespace Lynkco.Warranty.WebAPI.Application.Common.Mapper.Contracts
{
	public interface IMapper<TSource, TDestination>
	{
		TDestination Map(TSource source);
		IEnumerable<TDestination> MapCollection(IEnumerable<TSource> source);
	}
}
