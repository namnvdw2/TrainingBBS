// (c) 2026 W2 Co.,Ltd.

using w2.AccountDomain.Domains.Users;
using w2.ForumDomain.Domains.Forums;
using w2.WebFrontDomain.Dto.Forums;

namespace w2.WebFrontDomain.Interface
{
	/// <summary>
	/// IForumValidator
	/// </summary>
	public interface IForumValidator
	{
		/// <summary>
		/// Validate
		/// </summary>
		/// <param name="request">Post forum request</param>
		/// <returns>Forum response</returns>
		ForumResponse Validate(PostForumRequest request);

		/// <summary>
		/// Check access
		/// </summary>
		/// <param name="userId">User id</param>
		/// <param name="forum">Forum</param>
		/// <returns>Forum response</returns>
		ForumResponse CheckAccess(
			UserId userId,
			Forum forum);

		/// <summary>
		/// Check title
		/// </summary>
		/// <param name="title">Title</param>
		/// <returns>Error message</returns>
		string CheckTitle(string? title);

		/// <summary>
		/// Check text
		/// </summary>
		/// <param name="text">Text</param>
		/// <returns>Error message</returns>
		string CheckText(string? text);
	}
}
