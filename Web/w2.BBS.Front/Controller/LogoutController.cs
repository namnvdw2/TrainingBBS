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
	public sealed class LogoutController : BaseController
	{
		private readonly LoginLogoutService _loginLogoutService;

		/// <summary>
		/// Constructor
		/// </summary>
		public LogoutController(LoginLogoutService loginLogoutService) : base(loginLogoutService)
		{
			_loginLogoutService = loginLogoutService;
		}

		/// <summary>
		/// Index
		/// </summary>
		[HttpGet]
		[Route("")]
		public ActionResult Index()
		{
			return View("logout.liquid");
		}

		/// <summary>
		/// Logout
		/// </summary>
		[HttpPost]
		[Route("logout")]
		public ActionResult Logout()
		{
			var logoutResult = _loginLogoutService.Logout();
			return JsonForJs(logoutResult);
		}
	}
}
