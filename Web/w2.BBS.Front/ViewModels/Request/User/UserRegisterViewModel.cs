// (c) 2025 W2 Co.,Ltd.

using System;

namespace w2.BBS.Front.ViewModels.Request.User
{
	[Serializable]
	public class UserRegisterViewModel
	{
		public string LoginId { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
	}
}
