// (c) 2026 W2 Co.,Ltd.

namespace w2.WebFrontDomain.Dto.Forums
{
	/// <summary>
	/// Forum request
	/// </summary>
	public abstract class ForumRequest : BaseRequest
	{
		/// <summary>Title</summary>
		public string? Title { get; set; }
		/// <summary>Content</summary>
		public string? Content { get; set; }
	}
}
