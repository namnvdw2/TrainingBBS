// (c) 2026 W2 Co.,Ltd.

using System.Linq;
using w2.AccountDomain.Domains.Account;
using w2.AccountDomain.Dto.Account;
using w2.AccountDomain.RepositoryInterfaces.Account;
using w2.FoundationDomain.Helpers;
using w2.FoundationDomain.Repositories;

namespace w2.AccountDomain.RdbRepositories.Account
{
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
			var dto = _repository.GetWithBuilder<AccountDto>(
				f => f.Query("w2_Account").Where("id", id.AsString)).FirstOrDefault();
			return dto is not null ? AccountModel.CreateByDto(dto) : null;
		}

		/// <inheritdoc />rd
		public AccountModel? Get(LoginId loginId)
		{
			var dtoa = _repository.GetWithBuilder<AccountDto>(
				f => f.Query("w2_Account")).ToList();
			var dto = _repository.GetWithBuilder<AccountDto>(
				f => f.Query("w2_Account").Where("login_id", loginId.AsString)).FirstOrDefault();
			return dto is not null ? AccountModel.CreateByDto(dto) : null;
		}

		/// <inheritdoc />
		public void Insert(AccountModel account)
		{
			_repository.Execute("Insert", account.CreateDto().ToHashtable());
		}
	}
}
