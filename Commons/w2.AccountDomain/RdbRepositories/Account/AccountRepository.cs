// (c) 2026 W2 Co.,Ltd.

using System;
using System.Collections;
using System.Linq;
using w2.AccountDomain.Domains.Account;
using w2.AccountDomain.Dto.Account;
using w2.AccountDomain.RepositoryInterfaces.Account;
using w2.FoundationDomain.Helpers;
using w2.FoundationDomain.Repositories;

namespace w2.AccountDomain.RdbRepositories.Account
{
	/// <summary>
	/// Account repository
	/// </summary>
	public sealed class AccountRepository : IAccountRepository
	{
		private readonly ISqlRepository _repository;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public AccountRepository(ISqlRepository repository)
		{
			_repository = repository;
		}

		/// <inheritdoc />
		public AccountModel? Get(Id id)
		{
			var dto = _repository
				.GetWithBuilder<AccountDto>(f =>
					f.Query("w2_Account")
					.Where("id", id.AsString))
				.FirstOrDefault();
			return dto is not null ? AccountModel.CreateByDto(dto) : null;
		}

		/// <inheritdoc />
		public AccountModel? Get(LoginId loginId)
		{
			var dto = _repository.GetWithBuilder<AccountDto>(
				f => f.Query("w2_Account").Where("login_id", loginId.AsString)).FirstOrDefault();
			return dto is not null ? AccountModel.CreateByDto(dto) : null;
		}

		/// <inheritdoc />
		public void Insert(AccountModel account)
		{
			account.DateChanged = account.DateCreated = DateTime.Now;
			var input = account
				.CreateDto()
				.ToHashtable()
				.Cast<DictionaryEntry>()
				.ToDictionary(de => (string)de.Key, de => de.Value);
			_repository.ExecWithBuilder(f => f.Query("w2_Account").AsInsert(input));
		}
	}
}
