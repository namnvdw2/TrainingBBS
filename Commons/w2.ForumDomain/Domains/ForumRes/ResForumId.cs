// (c) 2026 W2 Co.,Ltd.

namespace w2.ForumDomain.Domains.ForumRes
{
	/// <summary>
	/// Response forum id
	/// </summary>
	/// <param name="AsInt">The id as int</param>
	public sealed record ResForumId(int AsInt)
	{
		/// <inheritdoc />
		public override string ToString()
		{
			return this.AsInt.ToString();
		}
	}
}

