// (c) 2026 W2 Co.,Ltd.

using System.Web.Mvc;
using w2.BBS.Front.Controller.Shared;
using w2.WebFrontDomain.Services.Users;

namespace w2.BBS.Front.Controller
{
	/// <summary>
	/// Index controller
	/// </summary>
	public sealed class IndexController : BaseController
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public IndexController(LoginLogoutService loginLogoutService) : base(loginLogoutService)
		{
		}

		/// <summary>
		/// Index
		/// </summary>
		[Route("~/")]
		public ActionResult Index()
		{
			return View("index.liquid");
		}
	}
}
