// (c) 2026 W2 Co.,Ltd.

using System;

namespace w2.AccountDomain.Domains.Users
{
	/// <summary>
	/// Date created value object
	/// </summary>
	/// <param name="AsDateTime">Date created as DateTime</param>
	[Serializable]
	public sealed record DateCreated(DateTime AsDateTime);
}
