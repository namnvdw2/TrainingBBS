// (c) 2026 W2 Co.,Ltd.

using System;

namespace w2.AccountDomain.Domains.Account
{
	/// <summary>
	/// Id
	/// </summary>
	[Serializable]
	public sealed record Id(string AsString)
	{
		/// <inheritdoc />
		public override string ToString()
		{
			return this.AsString.ToString();
		}
	}
}
