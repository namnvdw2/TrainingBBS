// (c) 2026 W2 Co.,Ltd.

using System;
using System.Collections;
using System.Linq;
using w2.AccountDomain.Domains.Users;
using w2.AccountDomain.Dto.Users;
using w2.AccountDomain.RepositoryInterfaces.Users;
using w2.Common.Helper.Attribute;
using w2.FoundationDomain.Helpers;
using w2.FoundationDomain.Repositories;

namespace w2.AccountDomain.RdbRepositories.Users
{
	/// <summary>
	/// User repository
	/// </summary>
	public sealed class UserRepository : IUserRepository
	{
		private readonly ISqlRepository _repository;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public UserRepository(ISqlRepository repository)
		{
			_repository = repository;
		}

		/// <inheritdoc />
		public User? Get(UserId id)
		{
			var dto = _repository
				.GetWithBuilder<UserDto>(f =>
					f.Query("w2_Account")
					.Where("id", id.AsInt))
				.FirstOrDefault();
			return dto is not null ? User.CreateByDto(dto) : null;
		}

		/// <inheritdoc />
		public User? Get(LoginId loginId)
		{
			var dto = _repository.GetWithBuilder<UserDto>(
				f => f.Query("w2_Account").Where("login_id", loginId.AsString)).FirstOrDefault();

			return dto is not null ? User.CreateByDto(dto) : null;
		}

		/// <inheritdoc />
		public void Insert(User user)
		{
			var dto = user.CreateDto();
			dto.DateChanged = DateTime.Now;
			dto.DateCreated = DateTime.Now;

			var input = dto
				.ToHashtable()
				.Cast<DictionaryEntry>()
				.ToDictionary(de => (string)de.Key, de => de.Value);

			_repository.ExecWithBuilder(f => f.Query("w2_Account").AsInsert(input));
		}

		/// <inheritdoc />
		public void Update(User exUser,
			User user)
		{
			var dto = exUser.CreateDto();
			dto.LoginId = user.LoginId.AsString;
			dto.UserName = user.UserName.AsString;
			dto.DateChanged = DateTime.Now;
			if (user.Password.HasRawValue()) dto.Password = user.Password.HashPassword;

			var input = dto
				.ToHashtable()
				.Cast<DictionaryEntry>()
				.ToDictionary(de => (string)de.Key, de => de.Value);
			_repository.ExecWithBuilder(f =>
				f.Query("w2_Account")
					.Where("id", exUser.UserId.AsInt)
					.AsUpdate(input));
		}

		/// <inheritdoc />
		public int Withdrawal(UserId userId)
		{
			var result = _repository.ExecWithBuilder(f =>
				f.Query("w2_Account")
				.Where("id", userId.AsInt)
				.Where("delete_flg", UsersWithdrawalStatus.Active.ToDbValue())
				.AsUpdate(new
				{
					delete_flg = UsersWithdrawalStatus.Canceled.ToDbValue(),
					date_changed = DateTime.Now
				}));

			return result;
		}
	}
}
