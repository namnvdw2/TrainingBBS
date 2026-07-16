// (c) 2026 W2 Co.,Ltd.

using System.Collections.Generic;

namespace w2.WebFrontDomain.Dto
{
	/// <summary>
	/// Pagination response object
	/// </summary>
	public sealed class PaginationResponseObject<T>
	{
		/// <summary>Items</summary>
		public IReadOnlyList<T>? Items { get; set; }
		/// <summary>Current page no</summary>
		public int CurrentPage { get; set; }
		/// <summary>Page size</summary>
		public int PageSize { get; set; }
		/// <summary>Total count</summary>
		public int TotalCount { get; set; }
		/// <summary>Total page</summary>
		public int TotalPage { get; set; }
		/// <summary>Has previous</summary>
		public bool HasPrevious => CurrentPage > 1;
		/// <summary>Has next</summary>
		public bool HasNext => CurrentPage < TotalPage;
	}
}
