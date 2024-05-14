using Lynkco.Warranty.WebAPI.Data.Common.Utilities.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Lynkco.Warranty.WebAPI.Application.Common.Utilities.Config
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
