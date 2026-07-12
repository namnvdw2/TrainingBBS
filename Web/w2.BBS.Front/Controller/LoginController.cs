// (c) 2026 W2 Co.,Ltd.

using System.Web.Mvc;
using w2.BBS.Front.Controller.Shared;
using w2.WebFrontDomain.Dto.Account;
using w2.WebFrontDomain.Services.Account;

namespace w2.BBS.Front.Controller
{
	/// <summary>
	/// Login controller
	/// </summary>
	public sealed class LoginController : BaseController
	{
		private LoginLogoutService _loginLogoutService;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="loginLogoutService">Login logout service</param>
		public LoginController(LoginLogoutService loginLogoutService)
		{
			_loginLogoutService = loginLogoutService;
		}

		/// <summary>
		/// Index
		/// </summary>
		/// <returns>Action result</returns>
		[HttpGet]
		[Route("~/login")]
		public ActionResult Index()
		{
			return View("login.liquid");
		}

		/// <summary>
		/// Login
		/// </summary>
		/// <param name="request">Login request</param>
		/// <returns>Action result</returns>
		[HttpPost]
		[Route("~/login")]
		public ActionResult Login(LoginRequest request)
		{
			var loginResult = _loginLogoutService.Login(request);
			return JsonForJs(loginResult);
		}
	}
}
