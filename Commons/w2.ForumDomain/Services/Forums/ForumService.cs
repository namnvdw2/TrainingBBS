// (c) 2026 W2 Co.,Ltd.

using w2.ForumDomain.Common;
using w2.ForumDomain.Domains.ForumRes;
using w2.ForumDomain.Domains.Forums;
using w2.ForumDomain.RepositoryInterfaces.Forums;
using w2.ForumDomain.RepositoryInterfaces.ForumsRes;

namespace w2.ForumDomain.Services.Forums
{
	/// <summary>
	/// Forum service
	/// </summary>
	public sealed class ForumService
	{
		private readonly IForumRepository _forumRepository;
		private readonly IForumResRepository _forumResRepository;

		/// <summary>
		/// Constructor
		/// </summary>
		public ForumService(IForumRepository forumRepository,
			IForumResRepository forumResRepository)
		{
			_forumRepository = forumRepository;
			_forumResRepository = forumResRepository;
		}

		/// <summary>
		/// Get all
		/// </summary>
		/// <param name="page">Page</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Pagination result</returns>
		public PaginationResult<Forum> GetAll(Page page, PageSize pageSize)
		{
			var result = _forumRepository.GetAll(page, pageSize);

			return result;
		}

		/// <summary>
		/// Get by id
		/// </summary>
		/// <param name="id">Forum id</param>
		/// <returns>Forum</returns>
		public Forum? GetById(ForumId id)
		{
			var forum = _forumRepository.Get(id);

			return forum;
		}

		/// <summary>
		/// Get response
		/// </summary>
		/// <param name="ids">Forum id list</param>
		/// <returns>Forum response list</returns>
		public ForumRes[] GetResponses(ForumId[] ids)
		{
			var forum = _forumResRepository.GetResponse(ids);

			return forum;
		}

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="forum">Forum</param>
		/// <returns>Forum inserted</returns>
		public Forum Insert(Forum forum)
		{
			_forumRepository.Insert(forum);

			return forum;
		}

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="forum">ForumRes</param>
		/// <returns>Forum response inserted</returns>
		public ForumRes InsertResponse(ForumRes forum)
		{
			_forumResRepository.InsertResponse(forum);

			return forum;
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="forum">Forum</param>
		/// <returns>Forum updated</returns>
		public Forum Update(Forum forum)
		{
			_forumRepository.Update(forum);

			return forum;
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="id">Forum id</param>
		/// <returns>Delete result</returns>
		public int Delete(ForumId id)
		{
			var result = _forumRepository.Delete(id);

			return result;
		}
	}
}
