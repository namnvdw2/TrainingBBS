// (c) 2025 W2 Co.,Ltd.

using System;
using w2.AccountDomain.Dto.Account;
using w2.Common.Helper.Attribute;

namespace w2.AccountDomain.Domains.Account
{
	/// <summary>
	/// Account model
	/// </summary>
	public sealed class AccountModel
	{
		/// <summary>
		/// Create by Dto
		/// </summary>
		/// <param name="dto">DTO</param>
		/// <returns>Account model</returns>
		public static AccountModel CreateByDto(AccountDto dto)
		{
			return new AccountModel
			{
				Id = new Id(dto.Id),
				LoginId = new LoginId(dto.LoginId),
				Name = new Name(dto.Name),
				Password = new Password(dto.Password),
				CancelFlag = DbValueAttribute.ParseToEnum<UserCancelStatus>(dto.DeleteFlg),
				DateCreated = dto.DateCreated,
				DateChanged = dto.DateChanged,
			};
		}

		/// <summary>
		/// Create Dto
		/// </summary>
		/// <returns>DTO</returns>
		public AccountDto CreateDto()
		{
			return new AccountDto
			{
				Id = this.Id.AsString,
				LoginId = this.LoginId.AsString,
				Name = this.Name.AsString,
				Password = this.Password.AsString,
				DateCreated = this.DateCreated,
				DateChanged = this.DateChanged,
			};
		}

		/// <summary>
		/// Can login user
		/// </summary>
		/// <param name="password">The password</param>
		/// <returns>True: user can login.</returns>
		public bool CanLogin(Password password)
		{
			if (string.IsNullOrEmpty(password.AsString)) return false;

			if (this.LoginId is null) return false;

			if (this.Password == password) return false;

			if (this.CancelFlag.IsCanceled()) return false;

			return true;
		}

		/// <summary>Id</summary>
		public Id Id { get; init; } = null!;
		/// <summary>Login id</summary>
		public LoginId LoginId { get; init; } = null!;
		/// <summary>Name</summary>
		public Name Name { get; init; } = null!;
		/// <summary>Password</summary>
		public Password Password { get; init; } = null!;
		/// <summary>Cancel flag</summary>
		public UserCancelStatus CancelFlag { get; init; }
		/// <summary>DateCreated</summary>
		public DateTime DateCreated { get; set; }
		/// <summary>Date changed</summary>
		public DateTime DateChanged { get; set; }
	}
}
