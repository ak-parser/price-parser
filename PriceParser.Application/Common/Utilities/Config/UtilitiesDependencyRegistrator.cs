using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using PriceParser.Data.Common.Utilities.Contracts;

namespace PriceParser.Application.Common.Utilities.Config
{
	[ExcludeFromCodeCoverage]
	public static class UtilitiesDependencyRegistrator
	{
		public static void RegisterDependencies(this IServiceCollection services)
		{
			services.AddTransient<IEpochHelper, EpochHelper>();
			services.AddTransient<IDateHelper, DateHelper>();
			services.AddTransient<PercentCalculator>();
		}
	}
}
