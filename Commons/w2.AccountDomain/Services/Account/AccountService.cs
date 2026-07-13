// (c) 2026 W2 Co.,Ltd.

using w2.AccountDomain.Domains.Account;
using w2.AccountDomain.RepositoryInterfaces.Account;

namespace w2.AccountDomain.Services.Account
{
	/// <summary>
	/// Account service
	/// </summary>
	public sealed class AccountService
	{
		/// <summary>Account repository</summary>
		private readonly IAccountRepository _accountRepository;

		/// <summary>
		/// Constructor
		/// </summary>
		public AccountService(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
		}

		/// <summary>
		/// Get by id
		/// </summary>
		/// <param name="id">Account id</param>
		/// <returns>Account</returns>
		public Domains.Account.Account? GetById(Id id)
		{
			var model = _accountRepository.Get(id);
			return model;
		}

		/// <summary>
		/// Get by login id
		/// </summary>
		/// <param name="loginId"></param>
		/// <returns>Account</returns>
		public Domains.Account.Account? GetByLoginId(LoginId loginId)
		{
			var model = _accountRepository.Get(loginId);
			return model;
		}

		/// <summary>
		/// Insert account
		/// </summary>
		/// <param name="account">Account</param>
		/// <returns>Account inserted</returns>

		public Domains.Account.Account Insert(Domains.Account.Account account)
		{
			var existed = _accountRepository.Get(account.LoginId);
			if (existed is null)
			{
				_accountRepository.Insert(account);
			}

			return account;
		}

		/// <summary>
		/// Update account
		/// </summary>
		/// <param name="id">Account id</param>
		/// <param name="account">Account</param>
		/// <returns>Account updated</returns>

		public Domains.Account.Account Update(Id id, Domains.Account.Account account)
		{
			var existed = _accountRepository.Get(id);
			if (existed is not null)
			{
				existed.LoginId = account.LoginId;
				existed.Name = account.Name;
				if (!string.IsNullOrEmpty(account.Password.ToString()))
				{
					existed.Password = account.Password;
				}

				_accountRepository.Update(existed);
			}

			return account;
		}

		/// <summary>
		/// Withdrawal
		/// </summary>
		/// <param name="accountId">Account id</param>
		/// <returns>Withdrawaled</returns>
		public int Withdrawal(Id accountId)
		{
			var existed = _accountRepository.Get(accountId);
			if (existed is null) return 0;

			return _accountRepository.Withdrawal(accountId);
		}
	}
}
