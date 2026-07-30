// (c) 2026 W2 Co.,Ltd.

using Humanizer;
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
		/// <param name="userName">User name</param>
		/// <param name="password">Password</param>
		/// <param name="withdrawalStatus">Users withdrawal status</param>
		/// <param name="dateCreated">Date created</param>
		/// <param name="dateChanged">Date changed</param>
		public User(UserId userId,
			LoginId loginId,
			UserName userName,
			Password password,
			UsersWithdrawalStatus withdrawalStatus,
			DateCreated dateCreated,
			DateChanged dateChanged)
		{
			this.UserId = userId;
			this.LoginId = loginId;
			this.UserName = userName;
			this.Password = password;
			this.WithdrawalStatus = withdrawalStatus;
			this.DateCreated = dateCreated;
			this.DateChanged = dateChanged;
		}

		/// <summary>
		/// Create user for modify
		/// </summary>
		/// <param name="loginId">Login id</param>
		/// <param name="userName">User name</param>
		/// <param name="password">Password</param>
		public static User CreateUserForModify(LoginId loginId,
			UserName userName,
			Password password)
		{
			return new User(new UserId(AsInt: int.MinValue),
				loginId,
				userName,
				password,
				UsersWithdrawalStatus.Active,
				new DateCreated(AsDateTime: DateTime.MinValue),
				new DateChanged(AsDateTime: DateTime.MinValue));
		}

		/// <summary>
		/// Create by Dto
		/// </summary>
		/// <param name="dto">DTO</param>
		/// <returns>User</returns>
		internal static User CreateByDto(UserDto dto)
		{
			return new User(new UserId(AsInt: dto.Id),
				new LoginId(AsString: dto.LoginId),
				new UserName(AsString: dto.UserName),
				Password.CreateFromBase64Encoded(dto.HashPassword),
				DbValueAttribute.ParseToEnum<UsersWithdrawalStatus>(dto.WithdrawalStatus),
				new DateCreated(AsDateTime: dto.DateCreated),
				new DateChanged(AsDateTime: dto.DateChanged));
		}

		/// <summary>
		/// Create Dto
		/// </summary>
		/// <returns>DTO</returns>
		internal UserDto CreateDto()
		{
			return new UserDto(
				this.UserId.AsInt,
				this.LoginId.AsString,
				this.UserName.AsString,
				this.WithdrawalStatus.ToDbValue(),
				this.DateCreated.AsDateTime,
				this.DateChanged.AsDateTime,
				this.Password.Encode());
		}

		/// <summary>
		/// Can login user
		/// </summary>
		/// <returns>True: user can login.</returns>
		public bool CanLogin(string password)
		{
			if (this.WithdrawalStatus.IsCanceled()) return false;

			if (!this.Password.Validate(password)) return false;

			return true;
		}

		/// <summary>User id</summary>
		public UserId UserId { get; }
		/// <summary>Login id</summary>
		public LoginId LoginId { get; }
		/// <summary>User name</summary>
		public UserName UserName { get; }
		/// <summary>Password</summary>
		public Password Password { get; }
		/// <summary>Cancel flag</summary>
		public UsersWithdrawalStatus WithdrawalStatus { get; }
		/// <summary>DateCreated</summary>
		public DateCreated DateCreated { get; }
		/// <summary>Date changed</summary>
		public DateChanged DateChanged { get; }
	}
}
