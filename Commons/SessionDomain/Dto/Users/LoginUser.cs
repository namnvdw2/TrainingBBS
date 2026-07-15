// (c) 2026 W2 Co.,Ltd.

using System;
using w2.AccountDomain.Domains.Users;

namespace SessionDomain.Dto.Users
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
		public static LoginUser CreateByUser(User user)
		{
			var result = new LoginUser(
				user.Id,
				user.LoginId,
				user.Name);

			return result;
		}

		/// <summary>User id</summary>
		public Id UserId { get; }
		/// <summary>User login ID</summary>
		public LoginId LoginId { get; }
		/// <summary>User name</summary>
		public Name Name { get; }
	}
}

