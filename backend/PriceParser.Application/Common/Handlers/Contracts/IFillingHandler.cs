﻿namespace PriceParser.Application.Common.Handlers.Contracts
{
	public interface IFillingHandler<TSource, TDestination>
	{
		Task Fill(TSource source, TDestination destination, CancellationToken cancellationToken);
	}
}
