using w2.FoundationDomain.Configurations;
using w2.WebFrontDomain.Configurations;

namespace w2.BBS.Front.ViewModels
{
	/// <summary>
	/// Base view model
	/// </summary>
	public class BaseViewModel
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
		/// <summary>Next url</summary>
		public string NextUrl { get; set; }
		/// <summary>Back url</summary>
		public string BackUrl { get; set; }
		/// <summary>Is logged in</summary>
		public bool IsLogin { get; set; }
		/// <summary>Login user name</summary>
		public string LoginUserName { get; set; }
	}
}
