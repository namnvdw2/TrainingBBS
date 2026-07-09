// (c) 2025 W2 Co.,Ltd.

namespace w2.ForumDomain.Domains.Forums
{
	/// <summary>
	/// Forum id
	/// </summary>
	/// <param name="AsInt">The id as int</param>
	public sealed record ForumId(int AsInt)
	{
		/// <inheritdoc />
		public override string ToString()
		{
			return this.AsInt.ToString();
		}
	}
}
