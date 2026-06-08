// (c) 2025 W2 Co.,Ltd.

namespace w2.AccountDomain.Domains.Account
{
	/// <summary>
	/// Login id
	/// </summary>
	/// <param name="AsString"></param>
	public sealed record LoginId(string AsString)
	{
		/// <inheritdoc />
		public override string ToString()
		{
			return this.AsString.ToString();
		}
	}
}
