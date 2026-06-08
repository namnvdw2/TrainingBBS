// (c) 2025 W2 Co.,Ltd.

namespace w2.AccountDomain.Domains.Account
{
	/// <summary>
	/// Password
	/// </summary>
	public sealed record Password(string AsString)
	{
		/// <inheritdoc />
		public override string ToString()
		{
			return this.AsString.ToString();
		}
	}
}
