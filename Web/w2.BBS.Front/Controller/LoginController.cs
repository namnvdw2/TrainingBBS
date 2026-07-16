// (c) 2026 W2 Co.,Ltd.

using System.Web.Mvc;
using w2.BBS.Front.Controller.Shared;
using w2.WebFrontDomain.Dto.Users;
using w2.WebFrontDomain.Services.Users;

namespace w2.BBS.Front.Controller
{
	/// <summary>
	/// Login controller
	/// </summary>
	public sealed class LoginController : BaseController
	{
		private readonly LoginLogoutService _loginLogoutService;

		/// <summary>
		/// Constructor
		/// </summary>
		public LoginController(LoginLogoutService loginLogoutService)
		{
			_loginLogoutService = loginLogoutService;
		}

		/// <summary>
		/// Index
		/// </summary>
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
		[HttpPost]
		[Route("~/login")]
		public ActionResult Login(LoginRequest request)
		{
			var loginResult = _loginLogoutService.Login(request);
			return JsonForJs(loginResult);
		}
	}
}
