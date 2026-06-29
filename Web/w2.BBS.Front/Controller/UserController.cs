// (c) 2025 W2 Co.,Ltd.

using System.Web.Mvc;
using w2.BBS.Front.Controller.Shared;
using w2.BBS.Front.ViewModels.Request.User;
using w2.WebFrontDomain.Dto.Account;
using w2.WebFrontDomain.Services.Account;

namespace w2.BBS.Front.Controller
{
	/// <summary>
	/// User controller
	/// </summary>
	[RoutePrefix("user")]
	public sealed class UserController : BaseController
	{
		/// <summary>Account register view service</summary>
		private readonly AccountRegisterViewService _registerService;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="registerService">Account register view service</param>
		public UserController(AccountRegisterViewService registerService)
		{
			_registerService = registerService;
		}

		/// <summary>
		/// Register input
		/// </summary>
		/// <returns>アクションリザルト</returns>
		[HttpGet]
		[Route("register/input")]
		public ActionResult RegisterInput()
		{
			return View("User/Register/input.liquid");
		}

		/// <summary>
		/// Register
		/// </summary>
		/// <returns>アクションリザルト</returns>
		[HttpPost]
		[Route("register")]
		public ActionResult Register(UserRegisterRequest request)
		{
			var response = _registerService.Validate(request);
			return JsonForJs(response);
		}

		/// <summary>
		/// Confirm view
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Route("register/confirm")]
		public ActionResult ConfirmView()
		{
			return View("User/Register/confirm.liquid");
		}
	}
}
