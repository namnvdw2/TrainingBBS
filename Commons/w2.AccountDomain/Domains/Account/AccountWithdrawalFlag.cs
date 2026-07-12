// (c) 2026 W2 Co.,Ltd.

using System;
using w2.Common.Helper.Attribute;

namespace w2.AccountDomain.Domains.Account
{
	/// <summary>
	/// Account withdrawal status
	/// </summary>
	[Serializable]
	public enum AccountWithdrawalStatus
	{
		[DbValue("0")]
		Active,
		[DbValue("1")]
		Canceled,
	}

	/// <summary>
	/// Account withdrawal flag
	/// </summary>
	[Serializable]
	public static class AccountWithdrawalFlag
	{
		/// <summary>Check if it's been drawaled</summary>
		public static bool IsCanceled(this AccountWithdrawalStatus value) => value == AccountWithdrawalStatus.Canceled;
	}
}
