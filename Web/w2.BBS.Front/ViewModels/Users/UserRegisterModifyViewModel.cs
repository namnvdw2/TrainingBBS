// (c) 2026 W2 Co.,Ltd.

namespace w2.BBS.Front.ViewModels.Users
{
	/// <summary>
	/// User register modify view model
	/// </summary>
	public class UserRegisterModifyViewModel : BaseViewModel
	{
		/// <summary>Login id</summary>
		public string LoginId { get; set; }
		/// <summary>Name</summary>
		public string Name { get; set; }
		/// <summary>Password</summary>
		public string Password { get; set; }
	}
}
