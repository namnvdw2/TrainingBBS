// (c) 2026 W2 Co.,Ltd.

using System.Web.Mvc;
using w2.BBS.Front.Codes.Attributes;
using w2.BBS.Front.Controller.Shared;
using w2.WebFrontDomain.Configurations;
using w2.WebFrontDomain.Dto.Forums;
using w2.WebFrontDomain.Services.Forums;
using w2.WebFrontDomain.Services.Users;
using w2.WebFrontDomain.ViewModels.Users;

namespace w2.BBS.Front.Controller
{
	/// <summary>
	/// User controller
	/// </summary>
	[CustomAuthorizeAttribute]
	[RoutePrefix("forum")]
	public sealed class ForumController : BaseController
	{
		private readonly ForumViewService _forumService;

		/// <summary>
		/// Constructor
		/// </summary>
		public ForumController(ForumViewService forumService,
			LoginLogoutService loginLogoutService) : base(loginLogoutService)
		{
			_forumService = forumService;
		}

		/// <summary>
		/// Forum top
		/// </summary>
		[HttpGet]
		[Route("")]
		public ActionResult ForumTop()
		{
			var loginUser = _forumService.GetLoginInformation();
			var viewModel = new LoginUserViewModel
			{
				LoginId = loginUser.LoginId.AsString,
				Name = loginUser.Name.AsString,
			};

			return View("Forum/forum.liquid", viewModel);
		}

		/// <summary>
		/// Get forums
		/// </summary>
		/// <param name="page">Page no</param>
		[HttpGet]
		[Route("get-forums")]
		public ActionResult GetForums(int page = 1)
		{
			var response = _forumService.GetForumPagination(
				page,
				ConstantsPage.DefaultPageSize);
			return JsonForJs(response);
		}

		/// <summary>
		/// Post forum
		/// </summary>
		/// <param name="request">Post forum request</param>
		[HttpPost]
		[Route("post-forum")]
		public ActionResult PostForum(PostForumRequest request)
		{
			var response = _forumService.PostForum(request);
			return JsonForJs(response);
		}

		/// <summary>
		/// Post reply
		/// </summary>
		/// <param name="request">Reply forum request</param>
		[HttpPost]
		[Route("post-reply")]
		public ActionResult PostReply(ReplyForumRequest request)
		{
			var response = _forumService.PostForumResponse(request);
			return JsonForJs(response);
		}

		/// <summary>
		/// Update forum
		/// </summary>
		/// <param name="request">Update forum request</param>
		[HttpPost]
		[Route("update-forum")]
		public ActionResult UpdateForum(UpdateForumRequest request)
		{
			var response = _forumService.UpdateForum(request);
			return JsonForJs(response);
		}

		/// <summary>
		/// Delete
		/// </summary>
		/// <param name="forumId">Forum id</param>
		[HttpPost]
		[Route("delete-forum")]
		public ActionResult Delete(int forumId)
		{
			var response = _forumService.DeleteForum(new ForumDomain.Domains.Forums.ForumId(forumId));
			return JsonForJs(response);
		}
	}
}
