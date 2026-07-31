// (c) 2026 W2 Co.,Ltd.

using w2.AccountDomain.Domains.Users;
using w2.ForumDomain.Domains.ForumRes;
using w2.ForumDomain.Domains.Forums;

namespace w2.ForumDomain.RepositoryInterfaces.ForumsRes
{
	/// <summary>
	/// Forum res repository interface
	/// </summary>
	public interface IForumResRepository
	{
		/// <summary>
		/// Get response
		/// </summary>
		/// <param name="ids">Forum id list</param>
		/// <returns>Forum response list</returns>
		ForumRes[] GetResponse(ForumId[] ids);

		/// <summary>
		/// Insert response
		/// </summary>
		/// <param name="forum">Forum response</param>
		void InsertResponse(ForumRes forum);

		/// <summary>
		/// Delete by user id
		/// </summary>
		/// <param name="id">User id</param>
		/// <returns>Deleted</returns>
		int DeleteByUserId(UserId id);
	}
}
