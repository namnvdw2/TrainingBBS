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

		/// <summary>Account register input page url</summary>
		public static string AccountRegisterInputPageUrl => $"{EnvironmentConfig.FrontRootPath}user/register/input";
		/// <summary>Account register confirm page url</summary>
		public static string AccountRegisterConfirmPageUrl => $"{EnvironmentConfig.FrontRootPath}user/register/confirm";
		/// <summary>Account register complete page url</summary>
		public static string AccountRegisterCompletePageUrl => $"{EnvironmentConfig.FrontRootPath}user/register/complete";
		/// <summary>Account modify input page url</summary>
		public static string AccountModifyInputPageUrl => $"{EnvironmentConfig.FrontRootPath}user/modify/input";
		/// <summary>Account modify confirm page url</summary>
		public static string AccountModifyConfirmPageUrl => $"{EnvironmentConfig.FrontRootPath}user/modify/confirm";
		/// <summary>Account cancel confirm page url</summary>
		public static string AccountCancelConfirmPageUrl => $"{EnvironmentConfig.FrontRootPath}user/withdrawal/confirm";
		/// <summary>Account cancel complete page url</summary>
		public static string AccountCancelCompletePageUrl => $"{EnvironmentConfig.FrontRootPath}user/withdrawal/complete";
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
