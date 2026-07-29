// (c) 2026 W2 Co.,Ltd.

using System;

namespace w2.AccountDomain.Domains.Users
{
	/// <summary>
	/// Hash password
	/// </summary>
	[Serializable]
	public sealed record HashPassword(string AsString);
}
