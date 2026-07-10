// (c) 2025 W2 Co.,Ltd.

namespace w2.WebFrontDomain.Dto.Forums
{
	/// <summary>
	/// Reply forum request
	/// </summary>
	public sealed class ReplyForumRequest : PostForumRequest
	{
		/// <summary>Forum id</summary>
		public int ForumId { get; set; }
	}
}
