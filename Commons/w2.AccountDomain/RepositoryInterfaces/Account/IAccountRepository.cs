// (c) 2025 W2 Co.,Ltd.

using w2.AccountDomain.Domains.Account;

namespace w2.AccountDomain.RepositoryInterfaces.Account
{
	public interface IAccountRepository
	{
		/// <summary>
		/// Get account by id
		/// </summary>
		/// <param name="id">Id</param>
		/// <returns>Account model</returns>
		AccountModel? Get(Id id);

		/// <summary>
		/// Get account by login id
		/// </summary>
		/// <param name="loginId">Login id</param>
		/// <returns>Account model</returns>
		AccountModel? Get(LoginId loginId);

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="account">Account model</param>
		void Insert(AccountModel account);
	}
}
