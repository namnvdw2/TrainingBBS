// (c) 2026 W2 Co.,Ltd.

using w2.ForumDomain.Common;
using w2.ForumDomain.Domains.ForumRes;
using w2.ForumDomain.Domains.Forums;

namespace w2.ForumDomain.RepositoryInterfaces.Forums
{
	/// <summary>
	/// IForumRepository
	/// </summary>
	public interface IForumRepository
	{
		/// <summary>
		/// Get all
		/// </summary>
		/// <returns></returns>
		PaginationResult<Forum> GetAll(Page page, PageSize pageSize);

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="id">ForumId</param>
		/// <returns></returns>
		Forum? Get(ForumId id);

		/// <summary>
		/// Get response
		/// </summary>
		/// <param name="ids">Forum id list</param>
		/// <returns>Forum response dto list</returns>
		ForumRes[] GetResponse(ForumId[] ids);

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="forum">Forum</param>
		void Insert(Forum forum);

		/// <summary>
		/// Insert response
		/// </summary>
		/// <param name="forum">Forum response</param>
		void InsertResponse(ForumRes forum);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="forum">Forum</param>
		int Update(Forum forum);

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="id">Forum id</param>
		/// <returns>deleted</returns>
		int Delete(ForumId id);

	}
}
