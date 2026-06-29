using System.Web.Mvc;
using w2.BBS.Front.Controller.Shared;

namespace w2.BBS.Front.Controller
{
	public class ErrorController : BaseController
	{
		public ActionResult NotFound()
		{
			Response.StatusCode = 404;
			Response.TrySkipIisCustomErrors = true;

			return View("Error/404.liquid");
		}
	}
}
