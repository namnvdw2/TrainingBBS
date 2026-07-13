// (c) 2026 W2 Co.,Ltd.

using System;
using System.Collections;
using System.Linq;
using w2.AccountDomain.Domains.Account;
using w2.AccountDomain.Dto.Account;
using w2.AccountDomain.RepositoryInterfaces.Account;
using w2.Common.Helper.Attribute;
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
		public Domains.Account.Account? Get(Id id)
		{
			var dto = _repository
				.GetWithBuilder<AccountDto>(f =>
					f.Query("w2_Account")
					.Where("id", id.AsInt))
				.FirstOrDefault();
			return dto is not null ? Domains.Account.Account.CreateByDto(dto) : null;
		}

		/// <inheritdoc />
		public Domains.Account.Account? Get(LoginId loginId)
		{
			var dto = _repository.GetWithBuilder<AccountDto>(
				f => f.Query("w2_Account").Where("login_id", loginId.AsString)).FirstOrDefault();
			return dto is not null ? Domains.Account.Account.CreateByDto(dto) : null;
		}

		/// <inheritdoc />
		public void Insert(Domains.Account.Account account)
		{
			account.DateChanged = new DateChanged(DateTime.Now);
			account.DateCreated = new DateCreated(DateTime.Now);
			var input = account
				.CreateDto()
				.ToHashtable()
				.Cast<DictionaryEntry>()
				.ToDictionary(de => (string)de.Key, de => de.Value);
			_repository.ExecWithBuilder(f => f.Query("w2_Account").AsInsert(input));
		}

		/// <inheritdoc />
		public void Update(Domains.Account.Account account)
		{
			account.DateChanged = new DateChanged(DateTime.Now);
			var input = account
				.CreateDto()
				.ToHashtable()
				.Cast<DictionaryEntry>()
				.ToDictionary(de => (string)de.Key, de => de.Value);
			_repository.ExecWithBuilder(f =>
				f.Query("w2_Account")
					.Where("id", account.Id.AsInt)
					.AsUpdate(input));
		}

		/// <inheritdoc />
		public int Withdrawal(Id accountId)
		{
			var result = _repository.ExecWithBuilder(f =>
				f.Query("w2_Account")
				.Where("id", accountId.AsInt)
				.Where("delete_flg", AccountWithdrawalStatus.Active.ToDbValue())
				.AsUpdate(new
				{
					delete_flg = AccountWithdrawalStatus.Canceled.ToDbValue(),
					date_changed = DateTime.Now
				}));
			return result;
		}
	}
}
