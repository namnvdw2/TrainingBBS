// (c) 2026 W2 Co.,Ltd.

using w2.ForumDomain.Common;
using w2.ForumDomain.Domains.Forums;

namespace w2.ForumDomain.RepositoryInterfaces.Forums
{
	/// <summary>
	/// Forum repository interface
	/// </summary>
	public interface IForumRepository
	{
		/// <summary>
		/// Get all
		/// </summary>
		/// <param name="page">Page</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Pagination forum</returns>
		PaginationResult<Forum> GetAll(Page page, PageSize pageSize);

		/// <summary>
		/// Get
		/// </summary>
		/// <param name="id">ForumId</param>
		/// <returns>Forum</returns>
		Forum? Get(ForumId id);

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="forum">Forum</param>
		void Insert(Forum forum);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="forum">Forum</param>
		/// <returns>Updated</returns>
		int Update(Forum forum);

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="id">Forum id</param>
		/// <returns>Deleted</returns>
		int Delete(ForumId id);

	}
}
