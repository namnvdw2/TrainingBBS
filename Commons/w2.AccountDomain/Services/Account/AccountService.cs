// (c) 2025 W2 Co.,Ltd.

using w2.AccountDomain.Domains.Account;
using w2.AccountDomain.Dto.Account;
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
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Domains.Account.Account? GetById(Id id)
		{
			var model = _accountRepository.Get(id);
			return model;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="loginId"></param>
		/// <returns></returns>
		public Domains.Account.Account? GetByLoginId(LoginId loginId)
		{
			var model = _accountRepository.Get(loginId);
			return model;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		/// <exception cref="System.Exception"></exception>

		public Domains.Account.Account Insert(Domains.Account.Account account)
		{
			var existed = _accountRepository.Get(account.LoginId);
			if (existed == null)
			{
				_accountRepository.Insert(account);
			}
			else
			{
				throw new System.Exception();
			}
			return account;
		}
	}
}
