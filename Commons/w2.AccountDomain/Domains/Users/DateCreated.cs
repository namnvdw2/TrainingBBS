// (c) 2026 W2 Co.,Ltd.

using System;

namespace w2.AccountDomain.Domains.Users
{
	/// <summary>
	/// Date changed value object
	/// </summary>
	/// <param name="AsDateTime">Date changed as DateTime</param>
	[Serializable]
	public sealed record DateCreated(DateTime AsDateTime);
}
