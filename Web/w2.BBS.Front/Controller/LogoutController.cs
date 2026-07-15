// (c) 2026 W2 Co.,Ltd.

using System.Web.Mvc;
using w2.BBS.Front.Controller.Shared;
using w2.WebFrontDomain.Services.Users;

namespace w2.BBS.Front.Controller
{
	/// <summary>
	/// Logout controller
	/// </summary>
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

		/// <summary>
		/// Index
		/// </summary>
		/// <returns>Action result</returns>
		[HttpGet]
		[Route("")]
		public ActionResult Index()
		{
			return View("logout.liquid");
		}

		/// <summary>
		/// Logout
		/// </summary>
		/// <returns>Action result</returns>
		[HttpPost]
		[Route("logout")]
		public ActionResult Logout()
		{
			var logoutResult = _loginLogoutService.Logout();
			return JsonForJs(logoutResult);
		}
	}
}
