// (c) 2025 W2 Co.,Ltd.

namespace w2.ForumDomain.Domains.Forums
{
	/// <summary>
	/// Forum User ID
	/// </summary>
	/// <param name="AsInt">The user id as int</param>
	public sealed record ForumUserId(int AsInt)
	{
		/// <inheritdoc />
		public override string ToString()
		{
			return this.AsInt.ToString();
		}
	}
}
