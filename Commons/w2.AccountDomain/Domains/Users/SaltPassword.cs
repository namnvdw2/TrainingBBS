// (c) 2026 W2 Co.,Ltd.

using System;

namespace w2.AccountDomain.Domains.Users
{
	/// <summary>
	/// Salt password
	/// </summary>
	[Serializable]
	public sealed record SaltPassword(string AsString);
}
