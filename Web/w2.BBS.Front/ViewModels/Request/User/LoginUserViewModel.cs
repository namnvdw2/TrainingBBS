// (c) 2025 W2 Co.,Ltd.

using System;

namespace w2.BBS.Front.ViewModels.Request.User
{
	[Serializable]
	public class LoginUserViewModel : BaseViewModel
	{
		public string LoginId { get; set; }
		public string Name { get; set; }
	}
}
