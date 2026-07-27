// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Repositories;
using System.Web.Mvc;
using w2.WebFrontDomain.Configurations;

namespace w2.BBS.Front.Codes.Attributes
{
	/// <summary>
	/// Custom authorize attribute
	/// </summary>
	public sealed class CustomAuthorizeAttribute : AuthorizeAttribute
	{
		/// <summary>
		/// On authorization
		/// </summary>
		/// <param name="filterContext">The authorization context</param>
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			var sessionUserRepository = new LoginUserSessionRepository(filterContext.HttpContext.Session);
			
			if (sessionUserRepository is not null && sessionUserRepository.ExistsLoggedIn())
			{
				filterContext.Result = new RedirectResult(ConstantsPage.LoginPageUrl);
			}
		}
	}
}
