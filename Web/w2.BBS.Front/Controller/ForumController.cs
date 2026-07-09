using System.Web.Mvc;
using w2.BBS.Front.Controller.Shared;
using w2.BBS.Front.ViewModels.Request.User;
using w2.WebFrontDomain.Services.Forums;

namespace w2.BBS.Front.Controller
{
	/// <summary>
	/// User controller
	/// </summary>
	[RoutePrefix("forum")]
	public sealed class ForumController : BaseController
	{
		/// <summary>Default page size</summary>
		private const int DEFAULT_PAGE_SIZE = 10;

		private readonly ForumViewService _forumService;

		/// <summary>
		/// Forum controller
		/// </summary>
		/// <param name="forumService">Forum view service</param>
		public ForumController(ForumViewService forumService)
		{
			_forumService = forumService;
		}

		[HttpGet]
		[Route("")]
		public ActionResult Index()
		{
			var loginUser = _forumService.GetLoginInformation();
			var viewModel = new LoginUserViewModel
			{
				LoginId = loginUser.LoginId.AsString,
				Name = loginUser.Name.AsString,
			};
			return View("Forum/forum.liquid", viewModel);
		}

		[HttpGet]
		[Route("get-forums")]
		public ActionResult GetForums(int page = 1)
		{
			var response = _forumService.GetForumPagination(
				page,
				DEFAULT_PAGE_SIZE);
			return JsonForJs(response);
		}

		[HttpPost]
		[Route("post-forum")]
		public ActionResult PostForum()
		{
			return View("Forum/forum.liquid");
		}
	}
}
