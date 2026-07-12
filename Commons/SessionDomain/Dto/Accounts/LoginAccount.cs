// (c) 2026 W2 Co.,Ltd.

using System;
using w2.AccountDomain.Domains.Account;

namespace SessionDomain.Dto.Accounts
{
	/// <summary>
	/// Login account
	/// </summary>
	[Serializable]
	public class LoginAccount
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public LoginAccount(
			Id accountId,
			LoginId loginId,
			Name name)
		{
			this.AccountId = accountId;
			this.LoginId = loginId;
			this.Name = name;
		}

		/// <summary>
		/// Create user login model by account model
		/// </summary>
		/// <param name="account">The account model</param>
		/// <returns>User login model</returns>
		public static LoginAccount CreateByUser(Account account)
		{
			var result = new LoginAccount(
				account.Id,
				account.LoginId,
				account.Name);

			return result;
		}

		/// <summary>Account id</summary>
		public Id AccountId { get; }
		/// <summary>Account login ID</summary>
		public LoginId LoginId { get; }
		/// <summary>Account name</summary>
		public Name Name { get; }
	}
}

