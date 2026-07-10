// (c) 2025 W2 Co.,Ltd.

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

		/// <summary>User register input page URL</summary>
		public static string UserRegisterInputPageUrl => $"{EnvironmentConfig.FrontRootPath}user/register/input";
		/// <summary>User register confirm page URL</summary>
		public static string UserRegisterConfirmPageUrl => $"{EnvironmentConfig.FrontRootPath}user/register/confirm";
		/// <summary>User register complete page URL</summary>
		public static string UserRegisterCompletePageUrl => $"{EnvironmentConfig.FrontRootPath}user/register/complete";
		/// <summary>User modify input page URL</summary>
		public static string UserModifyInputPageUrl => $"{EnvironmentConfig.FrontRootPath}user/modify/input";
		/// <summary>User modify confirm page URL</summary>
		public static string UserModifyConfirmPageUrl => $"{EnvironmentConfig.FrontRootPath}user/modify/confirm";
		/// <summary>User cancel confirm page URL</summary>
		public static string UserCancelConfirmPageUrl => $"{EnvironmentConfig.FrontRootPath}user/withdrawal/confirm";
		/// <summary>User cancel complete page URL</summary>
		public static string UserCancelCompletePageUrl => $"{EnvironmentConfig.FrontRootPath}user/withdrawal/complete";
		/// <summary>Login page URL</summary>
		public static string LoginPageUrl => $"{EnvironmentConfig.FrontRootPath}login";
		/// <summary>Logout page URL</summary>
		public static string LogoutPageUrl => $"{EnvironmentConfig.FrontRootPath}logout";
		/// <summary>Top forum page URL</summary>
		public static string TopForumPageUrl => $"{EnvironmentConfig.FrontRootPath}forum";

		/// <summary>
		/// Gets the error page URL
		/// </summary>
		/// <param name="nextUrl">Next URL</param>
		/// <returns>Error page URL</returns>
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
		/// Gets the default page size
		/// </summary>
		/// <returns>Page size</returns>
		public static int GetDefaultPageSize => DEFAULT_PAGE_SIZE;
	}
}
