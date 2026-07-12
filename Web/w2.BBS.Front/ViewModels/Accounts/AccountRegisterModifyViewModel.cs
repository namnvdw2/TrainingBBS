// (c) 2026 W2 Co.,Ltd.

namespace w2.BBS.Front.ViewModels.Accounts
{
	/// <summary>
	/// Account register modify view model
	/// </summary>
	public class AccountRegisterModifyViewModel : BaseViewModel
	{
		/// <summary>Login id</summary>
		public string LoginId { get; set; }
		/// <summary>Name</summary>
		public string Name { get; set; }
		/// <summary>Password</summary>
		public string Password { get; set; }
	}
}
