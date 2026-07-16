// (c) 2026 W2 Co.,Ltd.

using System;
using w2.AccountDomain.Dto.Users;
using w2.Common.Helper.Attribute;

namespace w2.AccountDomain.Domains.Users
{
	/// <summary>
	/// User
	/// </summary>
	[Serializable]
	public sealed class User
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="userId">User id</param>
		/// <param name="loginId">Login id</param>
		/// <param name="name">Name</param>
		/// <param name="password">Password</param>
		/// <param name="cancelFlag">Users withdrawal status</param>
		/// <param name="dateCreated">Date created</param>
		/// <param name="dateChanged">Date changed</param>
		public User(UserId userId,
			LoginId loginId,
			Name name,
			Password password,
			UsersWithdrawalStatus cancelFlag,
			DateCreated dateCreated,
			DateChanged dateChanged)
		{
			this.UserId = userId;
			this.LoginId = loginId;
			this.Name = name;
			this.Password = password;
			this.CancelFlag = cancelFlag;
			this.DateCreated = dateCreated;
			this.DateChanged = dateChanged;
		}

		/// <summary>
		/// Create user for modify
		/// </summary>
		/// <param name="loginId">Login id</param>
		/// <param name="name">Name</param>
		/// <param name="password">Password</param>
		public static User CreateUserForModify(string? loginId,
			string? name,
			string? password)
		{
			return new User(new UserId(int.MinValue),
				new LoginId(loginId ?? string.Empty),
				new Name(name ?? string.Empty),
				Password.FromPlainText(password ?? string.Empty),
				new UsersWithdrawalStatus(),
				new DateCreated(DateTime.MinValue),
				new DateChanged(DateTime.MinValue));
		}

		/// <summary>
		/// Create by Dto
		/// </summary>
		/// <param name="dto">DTO</param>
		/// <returns>User</returns>
		public static User CreateByDto(UserDto dto)
		{
			return new User(new UserId(dto.Id),
				new LoginId(dto.LoginId),
				new Name(dto.Name),
				Password.FromHash(dto.Password),
				DbValueAttribute.ParseToEnum<UsersWithdrawalStatus>(dto.DeleteFlg),
				new DateCreated(dto.DateCreated),
				new DateChanged(dto.DateChanged));
		}

		/// <summary>
		/// Create Dto
		/// </summary>
		/// <returns>DTO</returns>
		public UserDto CreateDto()
		{
			return new UserDto(
				this.UserId.AsInt,
				this.LoginId.AsString,
				this.Name.AsString,
				this.Password.HashPassword,
				this.CancelFlag.ToDbValue(),
				this.DateCreated.AsDateTime,
				this.DateChanged.AsDateTime);
		}

		/// <summary>
		/// Can login user
		/// </summary>
		/// <param name="password">The password</param>
		/// <returns>True: user can login.</returns>
		public bool CanLogin(Password password)
		{
			if (string.IsNullOrEmpty(password.RawPassword)) return false;

			if (this.LoginId is null) return false;

			if (!this.Password.Verify(password.RawPassword)) return false;

			if (this.CancelFlag.IsCanceled()) return false;

			return true;
		}

		/// <summary>User id</summary>
		public UserId UserId { get; init; }
		/// <summary>Login id</summary>
		public LoginId LoginId { get; init; }
		/// <summary>Name</summary>
		public Name Name { get; init; }
		/// <summary>Password</summary>
		public Password Password { get; init; }
		/// <summary>Cancel flag</summary>
		public UsersWithdrawalStatus CancelFlag { get; init; }
		/// <summary>DateCreated</summary>
		public DateCreated DateCreated { get; init; }
		/// <summary>Date changed</summary>
		public DateChanged DateChanged { get; init; }
	}
}
