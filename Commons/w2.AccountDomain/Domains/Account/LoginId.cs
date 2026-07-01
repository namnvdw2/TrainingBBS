// (c) 2025 W2 Co.,Ltd.

using System;

namespace w2.AccountDomain.Domains.Account
{
	/// <summary>
	/// Login id
	/// </summary>
	/// <param name="AsString"></param>
	[Serializable]
	public sealed record LoginId(string AsString)
	{
		/// <inheritdoc />
		public override string ToString()
		{
			return this.AsString.ToString();
		}
	}
}
