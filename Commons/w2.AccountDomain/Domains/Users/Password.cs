// (c) 2026 W2 Co.,Ltd.

using System;

namespace w2.AccountDomain.Domains.Users
{
	/// <summary>
	/// Password
	/// </summary>
	[Serializable]
	public sealed record Password(string AsString)
	{
		/// <inheritdoc />
		public override string ToString()
			=> AsString;
	}
}
