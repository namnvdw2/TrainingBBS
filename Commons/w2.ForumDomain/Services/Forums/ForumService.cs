// (c) 2025 W2 Co.,Ltd.

using System.Linq;
using w2.ForumDomain.Common;
using w2.ForumDomain.Domains.ForumRes;
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
		/// Get response
		/// </summary>
		/// <param name="ids">Forum id list</param>
		/// <returns>Forum response list</returns>
		public ForumRes[] GetResponses(ForumId[] ids)
		{
			var model = _forumRepository.GetResponse(ids);
			return model.Select(dto => ForumRes.CreateByDto(dto)).ToArray();
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
		/// <returns>Forum inserted</returns>

		public ForumRes InsertResponse(ForumRes forum)
		{
			_forumRepository.InsertResponse(forum);
			return forum;
		}

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="forum">Forum</param>
		/// <returns>Forum inserted</returns>

		public Forum Update(Forum forum)
		{
			_forumRepository.Update(forum);
			return forum;
		}

		/// <summary>
		/// GetById
		/// </summary>
		/// <param name="id">Forum id</param>
		/// <returns>Forum</returns>
		public int Delete(ForumId id)
		{
			var result = _forumRepository.Delete(id);
			return result;
		}
	}
}
