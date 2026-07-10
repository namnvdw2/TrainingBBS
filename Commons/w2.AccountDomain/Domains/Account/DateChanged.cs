// (c) 2025 W2 Co.,Ltd.

using System;

namespace w2.AccountDomain.Domains.Account
{
	/// <summary>
	/// Date changed value object
	/// </summary>
	/// <param name="AsDateTime">Date changed as DateTime</param>
	[Serializable]
	public sealed record DateChanged(DateTime AsDateTime);
}
