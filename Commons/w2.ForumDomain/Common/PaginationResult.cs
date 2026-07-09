// (c) 2025 W2 Co.,Ltd.

using System.Collections.Generic;

namespace w2.ForumDomain.Common
{
	public class PaginationResult<T>
	{
		public IReadOnlyList<T> Items { get; }
		public int TotalCount { get; }
		public PaginationResult(
			IReadOnlyList<T> items,
			int totalCount)
		{
			Items = items;
			TotalCount = totalCount;
		}
	}
}
