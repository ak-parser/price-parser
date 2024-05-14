﻿using Newtonsoft.Json;

namespace Lynkco.Warranty.WebAPI.Infrastructure.Common.Pagination
{
	public class PagedList<T> : List<T>
	{
		public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
		{
			TotalCount = count;
			PageSize = pageSize;
			CurrentPage = pageNumber;
			TotalPages = (int)Math.Ceiling(count / (double)pageSize);
			AddRange(items);
		}

		public int CurrentPage { get; }

		public int TotalPages { get; }

		public int PageSize { get; }

		public int TotalCount { get; }

		public bool HasPrevious => CurrentPage > 1;

		public bool HasNext => CurrentPage < TotalPages;

		public string CreateMetadata()
			=> JsonConvert.SerializeObject(new PaginationMetadata
			{
				TotalCount = TotalCount,
				PageSize = PageSize,
				CurrentPage = CurrentPage,
				TotalPages = TotalPages,
				HasNext = HasNext,
				HasPrevious = HasPrevious
			});
	}
}
