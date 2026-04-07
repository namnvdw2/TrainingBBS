// (c) 2025 W2 Co.,Ltd.

using System.Web.Mvc;
using w2.BBS.Front.Controller.Shared;
using w2.BBS.Front.ViewModels;

namespace w2.BBS.Front.Controller
{
	public sealed class LoginController : BaseController
	{
		/// <summary>
		/// トップページ
		/// </summary>
		/// <returns>アクションリザルト</returns>
		[HttpGet]
		[Route("~/login")]
		public ActionResult lll()
		{
			return View(
				"login.liquid");
		}
	}
}
