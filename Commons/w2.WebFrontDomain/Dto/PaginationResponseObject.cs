// (c) 2025 W2 Co.,Ltd.

using System.Collections.Generic;

namespace w2.WebFrontDomain.Dto
{
	public class PaginationResponseObject<T>
	{
		public IReadOnlyList<T>? Items { get; set; }

		public int CurrentPage { get; set; }

		public int PageSize { get; set; }

		public int TotalCount { get; set; }

		public int TotalPage { get; set; }

		public bool HasPrevious => CurrentPage > 1;

		public bool HasNext => CurrentPage < TotalPage;
	}
}
