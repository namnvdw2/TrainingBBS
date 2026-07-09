// (c) 2025 W2 Co.,Ltd.

using System;
using w2.ForumDomain.Domains.Forums;

namespace w2.WebFrontDomain.Dto.Forums
{
	/// <summary>
	/// Forum response
	/// </summary>
	public sealed class ForumResponse
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="forum">Forum</param>
		public ForumResponse(Forum forum)
		{
			ForumId = forum.ForumId.AsInt;
			Title = forum.Title.AsString;
			Text = forum.Text.AsString;
			UserName = forum.UserName.AsString;
			DateCreated = forum.DateCreated.AsDateTime;
			DateChanged = forum.DateChanged.AsDateTime;
		}

		/// <summary>Forum id</summary>
		public int ForumId { get; set; }
		/// <summary>Title</summary>
		public string? Title { get; set; }
		/// <summary>Text</summary>
		public string? Text { get; set; }
		/// <summary>User name</summary>
		public string? UserName { get; set; }
		/// <summary>Created date</summary>
		public DateTime DateCreated { get; set; }
		/// <summary>Updated date</summary>
		public DateTime DateChanged { get; set; }
	}
}
