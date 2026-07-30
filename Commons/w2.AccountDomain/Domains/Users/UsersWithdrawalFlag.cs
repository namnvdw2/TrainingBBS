// (c) 2026 W2 Co.,Ltd.

using System;
using w2.Common.Helper.Attribute;

namespace w2.AccountDomain.Domains.Users
{
	/// <summary>
	/// User withdrawal status
	/// </summary>
	[Serializable]
	public enum UsersWithdrawalStatus
	{
		/// <summary>Active</summary>
		[DbValue("0")]
		Active,
		/// <summary>Canceled</summary>
		[DbValue("1")]
		Canceled,
	}

	/// <summary>
	/// User withdrawal flag
	/// </summary>
	[Serializable]
	public static class UsersWithdrawalFlag
	{
		/// <summary>
		/// Check if it's been drawaled
		/// </summary>
		/// <param name="value">Users withdrawal status</param>
		/// <returns>True if canceled. Otherwise return false</returns>
		public static bool IsCanceled(this UsersWithdrawalStatus value) => value == UsersWithdrawalStatus.Canceled;
	}
}
