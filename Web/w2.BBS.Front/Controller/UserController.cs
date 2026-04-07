using System.Web.Mvc;
using w2.BBS.Front.Controller.Shared;

namespace w2.BBS.Front.Controller
{
    public class UserController : BaseController
	{
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}
