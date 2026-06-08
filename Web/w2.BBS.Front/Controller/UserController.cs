// (c) 2025 W2 Co.,Ltd.

using System.Web.Mvc;
using w2.BBS.Front.Controller.Shared;
using w2.BBS.Front.ViewModels.Request.User;

namespace w2.BBS.Front.Controller
{
	[RoutePrefix("user")]
	public sealed class UserController : BaseController
	{
		/// <summary>
		/// トップページ
		/// </summary>
		/// <returns>アクションリザルト</returns>
		[HttpGet]
		[Route("register/input")]
		public ActionResult RegisterInput()
		{
			return View(
				"User/Register/input.liquid");
		}

		/// <summary>
		/// トップページ
		/// </summary>
		/// <returns>アクションリザルト</returns>
		[HttpPost]
		[Route("register")]
		public ActionResult Register(UserRegisterViewModel request)
		{
			return Json(new { message = "OK" });
		}
	}
}

