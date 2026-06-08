// (c) 2025 W2 Co.,Ltd.

using w2.Common.Helper.Attribute;

namespace w2.AccountDomain.Domains.Account
{
	/// <summary>
	/// User cancel flag status
	/// </summary>
	public enum UserCancelStatus
	{
		[DbValue("0")]
		Active,
		[DbValue("1")]
		Canceled,
	}

	/// <summary>
	/// User cancel flag
	/// </summary>
	public static class UserCancelFlag
	{
		/// <summary>Check if it's been deleted</summary>
		public static bool IsCanceled(this UserCancelStatus value) => value == UserCancelStatus.Canceled;
	}
}
