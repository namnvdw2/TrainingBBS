// (c) 2026 W2 Co.,Ltd.

using w2.Common.Web;
using w2.FoundationDomain.Configurations;

namespace w2.WebFrontDomain.Configurations
{
	/// <summary>
	/// Constants page
	/// </summary>
	public static class ConstantsPage
	{
		/// <summary>Default page size</summary>
		private const int DEFAULT_PAGE_SIZE = 10;

		/// <summary>User register input page url</summary>
		public static string UserRegisterInputPageUrl => $"{EnvironmentConfig.FrontRootPath}user/register/input";
		/// <summary>User register confirm page url</summary>
		public static string UserRegisterConfirmPageUrl => $"{EnvironmentConfig.FrontRootPath}user/register/confirm";
		/// <summary>User register complete page url</summary>
		public static string UserRegisterCompletePageUrl => $"{EnvironmentConfig.FrontRootPath}user/register/complete";
		/// <summary>User modify input page url</summary>
		public static string UserModifyInputPageUrl => $"{EnvironmentConfig.FrontRootPath}user/modify/input";
		/// <summary>User modify confirm page url</summary>
		public static string UserModifyConfirmPageUrl => $"{EnvironmentConfig.FrontRootPath}user/modify/confirm";
		/// <summary>User cancel confirm page url</summary>
		public static string UserCancelConfirmPageUrl => $"{EnvironmentConfig.FrontRootPath}user/withdrawal/confirm";
		/// <summary>User cancel complete page url</summary>
		public static string UserCancelCompletePageUrl => $"{EnvironmentConfig.FrontRootPath}user/withdrawal/complete";
		/// <summary>Login page url</summary>
		public static string LoginPageUrl => $"{EnvironmentConfig.FrontRootPath}login";
		/// <summary>Logout page url</summary>
		public static string LogoutPageUrl => $"{EnvironmentConfig.FrontRootPath}logout";
		/// <summary>Top forum page url</summary>
		public static string TopForumPageUrl => $"{EnvironmentConfig.FrontRootPath}forum";

		/// <summary>
		/// Gets the error page url
		/// </summary>
		/// <param name="nextUrl">Next url</param>
		/// <returns>Error page url</returns>
		public static string GetErrorPageUrl(string nextUrl)
		{
			var urlCreator = new UrlCreator($"{EnvironmentConfig.FrontRootPath}error");
			if (string.IsNullOrEmpty(nextUrl) == false)
			{
				urlCreator.AddParam("nurl", nextUrl);
			}

			var result = urlCreator.CreateUrl();

			return result;
		}

		/// <summary>
		/// Default page size
		/// </summary>
		/// <returns>Page size</returns>
		public static int DefaultPageSize => DEFAULT_PAGE_SIZE;
	}
}
