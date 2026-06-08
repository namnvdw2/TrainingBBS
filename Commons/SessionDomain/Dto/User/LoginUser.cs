// (c) 2025 W2 Co.,Ltd.

using System;
using w2.AccountDomain.Domains.Account;

namespace SessionDomain.Dto.User
{
	/// <summary>
	/// Login user
	/// </summary>
	[Serializable]
	public class LoginUser
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="userId">The user ID</param>
		/// <param name="loginId">The user login ID</param>
		/// <param name="name">The user name</param>
		public LoginUser(
			Id userId,
			LoginId loginId,
			Name name)
		{
			this.UserId = userId;
			this.LoginId = loginId;
			this.Name = name;
		}

		/// <summary>
		/// Create user login model by user model
		/// </summary>
		/// <param name="user">The user model</param>
		/// <returns>User login model</returns>
		public static LoginUser CreateByUser(AccountModel user)
		{
			var result = new LoginUser(
				user.Id,
				user.LoginId,
				user.Name);

			return result;
		}

		/// <summary>User ID</summary>
		public Id UserId { get; }
		/// <summary>User login ID</summary>
		public LoginId LoginId { get; }
		/// <summary>User name</summary>
		public Name Name { get; }
	}
}

