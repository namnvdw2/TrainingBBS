// (c) 2026 W2 Co.,Ltd.

using w2.FoundationDomain.Configurations;
using w2.WebFrontDomain.Configurations;

namespace w2.WebFrontDomain.ViewModels
{
	/// <summary>
	/// Base view model
	/// </summary>
	public abstract class BaseViewModel
	{
		/// <summary>Root url</summary>
		public string RootUrl => EnvironmentConfig.FrontRootPath;
		/// <summary>Logout url</summary>
		public string LogoutUrl => ConstantsPage.LogoutPageUrl;
		/// <summary>Modify url</summary>
		public string ModifyUrl => ConstantsPage.UserModifyInputPageUrl;
		/// <summary>CancelUrl</summary>
		public string CancelUrl => ConstantsPage.UserCancelConfirmPageUrl;
		/// <summary>Login url</summary>
		public string LoginUrl => ConstantsPage.LoginPageUrl;
		/// <summary>Forum url</summary>
		public string ForumUrl => ConstantsPage.TopForumPageUrl;
		/// <summary>Is logged in</summary>
		public bool IsLogin { get; set; }
		/// <summary>Login user name</summary>
		public string? LoginUserName { get; set; }
		/// <summary>Next url</summary>
		public string? NextUrl { get; set; }
		/// <summary>Back url</summary>
		public string? BackUrl { get; set; }
	}
}
