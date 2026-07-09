// (c) 2025 W2 Co.,Ltd.

using w2.ForumDomain.Common;
using w2.ForumDomain.Domains.Forums;
using w2.ForumDomain.Dto.Forums;
using w2.ForumDomain.RepositoryInterfaces.Forums;

namespace w2.ForumDomain.Services.Forums
{
	public class ForumService
	{
		/// <summary>Account repository</summary>
		private readonly IForumRepository _forumRepository;

		/// <summary>
		/// Constructor
		/// </summary>
		public ForumService(IForumRepository forumRepository)
		{
			_forumRepository = forumRepository;
		}

		/// <summary>
		/// GetById
		/// </summary>
		/// <param name="id">Forum id</param>
		/// <returns>Forum</returns>
		public PaginationResult<Forum> GetAll(int page, int pageSize)
		{
			var result = _forumRepository.GetAll(page, pageSize);
			return result;
		}

		/// <summary>
		/// GetById
		/// </summary>
		/// <param name="id">Forum id</param>
		/// <returns>Forum</returns>
		public Forum? GetById(ForumId id)
		{
			var model = _forumRepository.Get(id);
			return model;
		}

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="forum">Forum</param>
		/// <returns>Forum inserted</returns>
		/// <exception cref="System.Exception"></exception>

		public Forum Insert(Forum forum)
		{
			var existed = _forumRepository.Get(forum.ForumId);
			if (existed == null)
			{
				_forumRepository.Insert(forum);
			}
			else
			{
				throw new System.Exception();
			}
			return forum;
		}
	}
}
