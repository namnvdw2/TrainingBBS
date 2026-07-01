using w2.FoundationDomain.Configurations;

namespace w2.BBS.Front.ViewModels
{
	/// <summary>
	/// Base view model
	/// </summary>
	public class BaseViewModel
	{
		/// <summary>Root url</summary>
		public string RootUrl => EnvironmentConfig.FrontRootPath;
		/// <summary>Next url</summary>
		public string NextUrl { get; set; }
		/// <summary>Back url</summary>
		public string BackUrl { get; set; }
	}
}
