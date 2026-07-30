// (c) 2026 W2 Co.,Ltd.

using System;

namespace w2.AccountDomain.Domains.Users
{
	/// <summary>
	/// Id
	/// </summary>
	/// <param name="AsInt">The user id as a int</param>
	[Serializable]
	public sealed record UserId(int AsInt)
	{
	}
}
