// (c) 2025 W2 Co.,Ltd.

using w2.Common.Helper.Attribute;

namespace w2.ForumDomain.Domains.Forum
{
	/// <summary>
	/// Forum Delete Flag Type
	/// </summary>
	public enum ForumDeleteFlagStatus
	{
		/// <summary>Active</summary>
		[DbValue("0")]
		Active,
		/// <summary>Deleted</summary>
		[DbValue("1")]
		Deleted,
	}

	/// <summary>
	/// Forum Delete Flag Type extension
	/// </summary>
	public static class ForumDeleteFlag
	{
		/// <summary>Check if it's been deleted</summary>
		public static bool IsDeleted(this ForumDeleteFlagStatus value) => value == ForumDeleteFlagStatus.Deleted;
	}
}
