// (c) 2025 W2 Co.,Ltd.

using SessionDomain.Dto.User;
using SessionDomain.Repositories;
using System;
using System.Linq;
using w2.ForumDomain.Domains.Forums;
using w2.ForumDomain.Services.Forums;
using w2.WebFrontDomain.Dto;
using w2.WebFrontDomain.Dto.Forums;

namespace w2.WebFrontDomain.Services.Forums
{
	/// <summary>
	/// Forum view service
	/// </summary>
	public class ForumViewService
	{
		private readonly ForumService _forumService;
		private readonly LoginUserSessionRepository _session;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="forumService">Forum service</param>
		/// <param name="session">Login user session repository</param>
		public ForumViewService(
			ForumService forumService,
			LoginUserSessionRepository session)
		{
			_forumService = forumService;
			_session = session;
		}

		public LoginUser? GetLoginInformation()
		{
			return _session.ExistsUser() ? _session.LoginUser : null;
		}

		public ForumPaginationResponse GetForumPagination(
			int page,
			int pageSize)
		{
			var result = _forumService.GetAll(page, pageSize);

			return new ForumPaginationResponse
			{
				ResponseObject = new PaginationResponseObject<ForumResponse>
				{
					Items = result.Items
						.Select(forum => new ForumResponse(forum))
						.ToList(),
					CurrentPage = page,
					PageSize = pageSize,
					TotalCount = result.TotalCount,
					TotalPage = (int)Math.Ceiling((double)result.TotalCount / pageSize)
				}
			};
		}
	}
}
