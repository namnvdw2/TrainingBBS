using System.Web.Mvc;
using w2.BBS.Front.Controller.Shared;

namespace w2.BBS.Front.Controller
{
	/// <summary>
	/// User controller
	/// </summary>
	[RoutePrefix("forum")]
	public sealed class ForumController : BaseController
	{
		[HttpGet]
		[Route("")]
		public ActionResult Index()
		{
			return View("Forum/forum.liquid");
		}
	}
}
