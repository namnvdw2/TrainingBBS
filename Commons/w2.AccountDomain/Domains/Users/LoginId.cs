// (c) 2026 W2 Co.,Ltd.

using System;

namespace w2.AccountDomain.Domains.Users
{
	/// <summary>
	/// Login id
	/// </summary>
	/// <param name="AsString">As string</param>
	[Serializable]
	public sealed record LoginId(string AsString);
}
