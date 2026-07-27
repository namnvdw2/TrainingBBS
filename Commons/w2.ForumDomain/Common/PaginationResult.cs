// (c) 2026 W2 Co.,Ltd.

using System.Collections.Generic;

namespace w2.ForumDomain.Common
{
	/// <summary>
	/// Pagination result
	/// </summary>
	/// <typeparam name="T">Pagination list object</typeparam>
	public sealed class PaginationResult<T>
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="items">Items</param>
		/// <param name="totalCount">Total count</param>
		public PaginationResult(
			IReadOnlyList<T> items,
			int totalCount)
		{
			Items = items;
			TotalCount = totalCount;
		}

		/// <summary>Items</summary>
		public IReadOnlyList<T> Items { get; }
		/// <summary>Total count</summary>
		public int TotalCount { get; }
	}
}
