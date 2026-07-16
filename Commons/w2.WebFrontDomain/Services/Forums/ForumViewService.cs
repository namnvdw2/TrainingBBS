// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Dto.Users;
using SessionDomain.Repositories;
using System;
using System.Linq;
using w2.ForumDomain.Domains.ForumRes;
using w2.ForumDomain.Domains.Forums;
using w2.ForumDomain.Services.Forums;
using w2.WebFrontDomain.Dto;
using w2.WebFrontDomain.Dto.Forums;
using w2.WebFrontDomain.Validator.Forums;
using static System.Net.Mime.MediaTypeNames;

namespace w2.WebFrontDomain.Services.Forums
{
	/// <summary>
	/// Forum view service
	/// </summary>
	public sealed class ForumViewService
	{
		private readonly ForumService _forumService;
		private readonly LoginUserSessionRepository _session;

		/// <summary>
		/// Constructor
		/// </summary>
		public ForumViewService(
			ForumService forumService,
			LoginUserSessionRepository session)
		{
			_forumService = forumService;
			_session = session;
		}

		/// <summary>
		/// Get login information
		/// </summary>
		/// <returns>Login user</returns>
		public LoginUser? GetLoginInformation()
		{
			return _session.ExistsLoggedIn() ? _session.LoginUser : null;
		}

		/// <summary>
		/// Get Forum Pagination
		/// </summary>
		/// <param name="page">Page number</param>
		/// <param name="pageSize">Page size</param>
		/// <returns>Forum pagination response</returns>
		public ForumPaginationResponse GetForumPagination(
			int page,
			int pageSize)
		{
			if (!_session.ExistsLoggedIn()) return ResponseFactory.Error<ForumPaginationResponse>();
			var loginUser =  _session.LoginUser;
			var result = _forumService.GetAll(page, pageSize);
			var responseIds = result.Items.Select(x => x.ForumId).ToArray();
			var forumResponses = _forumService.GetResponses(responseIds);

			var response = ResponseFactory.Success<ForumPaginationResponse>();
			response.ResponseObject = new PaginationResponseObject<ForumResponseDto>
			{
				Items = result.Items.Select(forum =>
				{
					var responseDto = new ForumResponseDto(forum);
					responseDto.IsOwner = loginUser.UserId.AsInt == responseDto.UserId;
					if (forumResponses is not null)
					{
						var responseList = forumResponses
							.Where(res => responseDto.ForumId == res.ForumId.AsInt)
							.Select(res => new ForumResResponseDto(res))
							.ToList();
						responseDto.SetResponses(responseList);
					}
					return responseDto;
				}).ToList(),
				CurrentPage = page,
				PageSize = pageSize,
				TotalCount = result.TotalCount,
				TotalPage = (int)Math.Ceiling((double)result.TotalCount / pageSize)
			};
			return response;
		}

		/// <summary>
		/// Post forum
		/// </summary>
		/// <param name="request">Post forum request</param>
		/// <returns>Forum response</returns>
		public ForumResponse PostForum(PostForumRequest request)
		{
			if (!_session.ExistsLoggedIn()) return ResponseFactory.Error<ForumResponse>();

			var response = ForumValidator.Validate(request);
			if (response.HasError) return (ForumResponse)response;

			var loginUser = _session.LoginUser;
			var result = _forumService.Insert(new Forum(
				new ForumUserId(loginUser.UserId.AsInt),
				new ForumTitle(request.Title ?? string.Empty),
				new ForumText(request.Content ?? string.Empty)));

			if (result is not null) response.ResponseObject = result;

			return response;
		}

		/// <summary>
		/// Post forum response
		/// </summary>
		/// <param name="request">Reply forum request</param>
		/// <returns>Forum response</returns>
		public ForumResponse PostForumResponse(ReplyForumRequest request)
		{
			if (!_session.ExistsLoggedIn()) return ResponseFactory.Error<ForumResponse>();

			var loginUser = _session.LoginUser;
			var forum = _forumService.GetById(new ForumDomain.Domains.Forums.ForumId(request.ForumId));
			if (forum is null) return ResponseFactory.Error<ForumResponse>();

			var response = ForumValidator.Validate(request);
			if (response.HasError) return (ForumResponse)response;
			var forumResponse = new ForumRes(
				new ResForumId(AsInt: 0),
				new ForumId(forum.ForumId.AsInt),
				new ForumUserId(loginUser.UserId.AsInt),
				new ForumTitle(request.Title ?? string.Empty),
				new ForumText(request.Content ?? string.Empty),
				ForumDeleteFlagStatus.Active,
				new DateCreated(forum.DateCreated.AsDateTime),
				new DateChanged(forum.DateChanged.AsDateTime));

			_forumService.InsertResponse(forumResponse);

			return response;
		}

		/// <summary>
		/// Update forum
		/// </summary>
		/// <param name="request">Update forum request</param>
		/// <returns>Forum response</returns>
		public ForumResponse UpdateForum(UpdateForumRequest request)
		{
			if (!_session.ExistsLoggedIn()) return ResponseFactory.Error<ForumResponse>();

			var loginUser = _session.LoginUser;
			var forum = _forumService.GetById(new ForumDomain.Domains.Forums.ForumId(request.ForumId));
			if (forum is null) return ResponseFactory.Error<ForumResponse>();

			var response = ForumValidator.CheckAssess(
				loginUser.UserId.AsInt,
				forum);
			if (!response.Success) return (ForumResponse)response;

			response = ForumValidator.Validate(request);
			if (response.HasError) return (ForumResponse)response;

			var forumUpdated = new Forum(
				forum.ForumId,
				forum.UserId,
				new ForumTitle(request.Title ?? string.Empty),
				new ForumText(request.Content ?? string.Empty),
				forum.DeleteFlag,
				forum.DateCreated,
				forum.DateChanged);
			var result = _forumService.Update(forumUpdated);
			if (result is not null) response.ResponseObject = result;

			return response;
		}

		/// <summary>
		/// Delete forum
		/// </summary>
		/// <returns>Forum Response</returns>
		public ForumResponse DeleteForum(int forumId)
		{
			if (!_session.ExistsLoggedIn()) return ResponseFactory.Error<ForumResponse>();

			var loginUser = _session.LoginUser;
			var forum = _forumService.GetById(new ForumDomain.Domains.Forums.ForumId(forumId));
			if (forum is null) return ResponseFactory.Error<ForumResponse>();

			var response = ForumValidator.CheckAssess(
				loginUser.UserId.AsInt,
				forum);
			if (!response.Success) return response;

			var result = _forumService.Delete(new ForumId(forumId));
			if(result == 0) return ResponseFactory.Error<ForumResponse>();

			return response;
		}
	}
}
