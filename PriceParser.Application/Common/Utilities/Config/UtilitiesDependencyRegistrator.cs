using Microsoft.Extensions.DependencyInjection;
using PriceParser.Application.Common.Utilities;
using PriceParser.Data.Common.Utilities.Contracts;
using System.Diagnostics.CodeAnalysis;

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
