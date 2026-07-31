// (c) 2026 W2 Co.,Ltd.

using System;
using System.Collections.Generic;
using w2.ForumDomain.Domains.Forums;

namespace w2.WebFrontDomain.Dto.Forums
{
	/// <summary>
	/// Forum response
	/// </summary>
	public sealed class ForumResponseDto
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="forum">Forum</param>
		public ForumResponseDto(Forum forum)
		{
			ForumId = forum.ForumId.AsInt;
			Title = forum.Title.AsString;
			Text = forum.Text.AsString;
			UserId = forum.UserId.AsInt;
			UserName = forum.UserName.AsString;
			DateCreated = forum.DateCreated.ToString();
			DateChanged = forum.DateChanged.ToString();
			IsOwner = false;
			Responses = new List<ForumResResponseDto>();
		}

		/// <summary>
		/// Set responses
		/// </summary>
		/// <param name="responses">Responses</param>
		public void SetResponses(List<ForumResResponseDto> responses)
		{
			Responses = responses;
		}

		/// <summary>Forum id</summary>
		public int ForumId { get; set; }
		/// <summary>Title</summary>
		public string? Title { get; set; }
		/// <summary>Text</summary>
		public string? Text { get; set; }
		/// <summary>User id</summary>
		public int UserId { get; set; }
		/// <summary>User name</summary>
		public string? UserName { get; set; }
		/// <summary>Created date</summary>
		public string DateCreated { get; set; }
		/// <summary>Updated date</summary>
		public string DateChanged { get; set; }
		/// <summary>Is owner</summary>
		public bool IsOwner { get; set; }
		/// <summary>Responses</summary>
		public List<ForumResResponseDto> Responses { get; set; }
	}
}
