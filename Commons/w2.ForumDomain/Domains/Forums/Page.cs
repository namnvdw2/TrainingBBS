// (c) 2026 W2 Co.,Ltd.

using System;

namespace w2.ForumDomain.Domains.Forums
{
	/// <summary>
	/// Page
	/// </summary>
	/// <param name="AsInt">As int</param>
	public sealed record Page(int AsInt)
	{
		/// <summary>
		/// Get skip
		/// </summary>
		/// <param name="pageSize">Page size</param>
		/// <returns>Number of record is skiped</returns>
		public int GetSkip(int pageSize)
		{
			return Math.Max(0, (AsInt - 1) * pageSize);
		}
	}
}
