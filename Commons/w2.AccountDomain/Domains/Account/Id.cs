// (c) 2026 W2 Co.,Ltd.

namespace w2.AccountDomain.Domains.Account
{
	/// <summary>
	/// Id
	/// </summary>
	public sealed record Id(string AsString)
	{
		/// <inheritdoc />
		public override string ToString()
		{
			return this.AsString.ToString();
		}
	}
}
