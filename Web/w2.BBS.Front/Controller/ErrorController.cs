// (c) 2026 W2 Co.,Ltd.

using System.Web.Mvc;
using w2.BBS.Front.Controller.Shared;

namespace w2.BBS.Front.Controller
{
	/// <summary>
	/// Error controller
	/// </summary>
	public sealed class ErrorController : BaseController
	{
		/// <summary>
		/// Not found
		/// </summary>
		public ActionResult NotFound()
		{
			Response.StatusCode = 404;
			Response.TrySkipIisCustomErrors = true;

			return View("Error/404.liquid");
		}
	}
}
