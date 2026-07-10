// (c) 2025 W2 Co.,Ltd.

using SessionDomain.Repositories;
using System.Web;
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
		/// Authorize core
		/// </summary>
		/// <param name="httpContext">Http context base</param>
		/// <returns>True if authorized, otherwise return false</returns>
		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			var session = DependencyResolver.Current
				.GetService<LoginUserSessionRepository>();

			return session is not null && session.ExistsUser();
		}

		/// <summary>
		/// Handle unauthorized request
		/// </summary>
		/// <param name="filterContext">Authorization context</param>
		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
		{
			if (filterContext.HttpContext.Request.IsAjaxRequest())
			{
				filterContext.Result = new JsonResult
				{
					Data = new
					{
						Success = false,
						Message = "ログインしてください。"
					},
					JsonRequestBehavior = JsonRequestBehavior.AllowGet
				};

				filterContext.HttpContext.Response.StatusCode = 401;
				return;
			}

			filterContext.Result = new RedirectResult(ConstantsPage.LoginPageUrl);
		}
	}
}
