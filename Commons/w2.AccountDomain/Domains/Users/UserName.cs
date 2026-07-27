// (c) 2026 W2 Co.,Ltd.

using System;

namespace w2.AccountDomain.Domains.Users
{
	/// <summary>
	/// User name
	/// </summary>
	[Serializable]
	public sealed record UserName(string AsString);
}
