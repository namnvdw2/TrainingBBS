// (c) 2026 W2 Co.,Ltd.

namespace w2.WebFrontDomain.Dto.Forums
{
	/// <summary>
	/// Update forum request
	/// </summary>
	public sealed class UpdateForumRequest : ForumRequest
	{
		/// <summary>Forum id</summary>
		public int ForumId { get; set; }
	}
}
