// (c) 2025 W2 Co.,Ltd.

using System.Web.Mvc;
using w2.BBS.Front.Controller.Shared;
using w2.WebFrontDomain.Dto.Account;
using w2.WebFrontDomain.Services.Account;

namespace w2.BBS.Front.Controller
{
	public sealed class LoginController : BaseController
	{
		private LoginLogoutService _loginLogoutService;
		public LoginController(LoginLogoutService loginLogoutService)
		{
			_loginLogoutService = loginLogoutService;
		}

		[HttpGet]
		[Route("~/login")]
		public ActionResult Index()
		{
			return View("login.liquid");
		}

		[HttpPost]
		[Route("~/login")]
		public ActionResult Login(LoginRequest request)
		{
			var loginResult = _loginLogoutService.Login(request);
			return JsonForJs(loginResult);
		}
	}
}
