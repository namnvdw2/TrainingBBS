// (c) 2026 W2 Co.,Ltd.

using System.Web.Mvc;
using w2.BBS.Front.Controller.Shared;

namespace w2.BBS.Front.Controller
{
	/// <summary>
	/// Index controller
	/// </summary>
	public sealed class IndexController : BaseController
	{
		/// <summary>
		/// Index
		/// </summary>
		/// <returns>Action result</returns>
		[Route("~/")]
		public ActionResult Index()
		{
			return View("index.liquid");
		}
	}
}
