// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Interface;
using System;
using System.Linq;
using w2.AccountDomain.Domains.Users;
using w2.ForumDomain.Domains.ForumRes;
using w2.ForumDomain.Domains.Forums;
using w2.ForumDomain.Services.Forums;
using w2.WebFrontDomain.Dto;
using w2.WebFrontDomain.Dto.Forums;
using w2.WebFrontDomain.Interface;
using w2.WebFrontDomain.ViewModels;
using w2.WebFrontDomain.ViewModels.Users;

namespace w2.WebFrontDomain.Services.Forums
{
	/// <summary>
	/// Forum view service
	/// </summary>
	public sealed class ForumViewService
	{
		private readonly ForumService _forumService;
		private readonly ILoginUserSessionRepository _session;
		private readonly IForumValidator _validator;

		/// <summary>
		/// Constructor
		/// </summary>
		public ForumViewService(
			ForumService forumService,
			ILoginUserSessionRepository session,
			IForumValidator validator)
		{
			_forumService = forumService;
			_session = session;
			_validator = validator;
		}

		/// <summary>
		/// Get login information
		/// </summary>
		/// <returns>Login user view model</returns>
		public BaseViewModel GetLoginInformation()
		{
			if (!_session.ExistsLoggedIn()) return new EmptyViewModel();

			var viewModel = new LoginUserViewModel
			{
				LoginId = _session.LoginUser.LoginId.AsString,
				Name = _session.LoginUser.Name.AsString,
			};

			return viewModel;
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
			var loginUser = _session.LoginUser;
			var result = _forumService.GetAll(new Page(AsInt: page),
				new PageSize(AsInt: pageSize));
			var responseIds = result.Items.Select(x => x.ForumId).ToArray();
			var forumResponses = _forumService.GetResponses(responseIds);

			var response = ResponseFactory.Success<ForumPaginationResponse>();
			response.ResponseObject = new PaginationResponseObject<ForumResponseDto>
			{
				Items = result.Items.Select(forum =>
				{
					var responseDto = new ForumResponseDto(forum);
					responseDto.IsOwner = loginUser.UserId.AsInt == responseDto.UserId;
					if (forumResponses.Length > 0)
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
				TotalPage = result.GetTotalPage(pageSize)
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

			var response = _validator.Validate(request);
			if (response.HasError) return response;

			var loginUser = _session.LoginUser;
			var result = _forumService.Insert(new Forum(
				new UserId(loginUser.UserId.AsInt),
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

			var response = _validator.Validate(request);
			if (response.HasError) return response;
			var forumResponse = new ForumRes(
				new ForumId(forum.ForumId.AsInt),
				new UserId(loginUser.UserId.AsInt),
				new ForumTitle(request.Title ?? string.Empty),
				new ForumText(request.Content ?? string.Empty));

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

			var response = _validator.CheckAccess(
				loginUser.UserId,
				forum);
			if (!response.Success) return response;

			response = _validator.Validate(request);
			if (response.HasError) return response;

			var forumUpdated = new Forum(
				forum.ForumId,
				forum.UserId,
				forum.UserName,
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
		/// <param name="forumId">Forum id</param>
		/// <returns>Forum Response</returns>
		public ForumResponse DeleteForum(int forumId)
		{
			if (!_session.ExistsLoggedIn()) return ResponseFactory.Error<ForumResponse>();

			var loginUser = _session.LoginUser;
			var forum = _forumService.GetById(new ForumId(forumId));
			if (forum is null) return ResponseFactory.Error<ForumResponse>();

			var response = _validator.CheckAccess(
				loginUser.UserId,
				forum);
			if (!response.Success) return response;

			var result = _forumService.Delete(new ForumId(forumId));
			if(result == 0) return ResponseFactory.Error<ForumResponse>();

			return response;
		}
	}
}
