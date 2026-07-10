// (c) 2025 W2 Co.,Ltd.

using System.Web.Mvc;
using w2.BBS.Front.Controller.Shared;
using w2.WebFrontDomain.Services.Account;

namespace w2.BBS.Front.Controller
{
	[RoutePrefix("logout")]
	public class LogoutController : BaseController
	{
		private LoginLogoutService _loginLogoutService;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="loginLogoutService">Login logout service</param>
		public LogoutController(LoginLogoutService loginLogoutService)
		{
			_loginLogoutService = loginLogoutService;
		}

		[HttpGet]
		[Route("")]
		public ActionResult Index()
		{
			return View("logout.liquid");
		}

		[HttpPost]
		[Route("logout")]
		public ActionResult Logout()
		{
			var logoutResult = _loginLogoutService.Logout();
			return JsonForJs(logoutResult);
		}
	}
}
