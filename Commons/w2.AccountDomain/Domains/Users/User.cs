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
		/// <param name="userName">User name</param>
		/// <param name="password">Password</param>
		/// <param name="hashPassword">Hash password</param>
		/// <param name="saltPassword">Salt password</param>
		/// <param name="withdrawalStatus">Users withdrawal status</param>
		/// <param name="dateCreated">Date created</param>
		/// <param name="dateChanged">Date changed</param>
		public User(UserId userId,
			LoginId loginId,
			UserName userName,
			Password password,
			HashPassword hashPassword,
			SaltPassword saltPassword,
			UsersWithdrawalStatus withdrawalStatus,
			DateCreated dateCreated,
			DateChanged dateChanged)
		{
			this.UserId = userId;
			this.LoginId = loginId;
			this.UserName = userName;
			this.Password = password;
			this.HashPassword = hashPassword;
			this.SaltPassword = saltPassword;
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
				new HashPassword(AsString: string.Empty),
				new SaltPassword(AsString: string.Empty),
				new UsersWithdrawalStatus(),
				new DateCreated(AsDateTime: DateTime.MinValue),
				new DateChanged(AsDateTime: DateTime.MinValue));
		}

		/// <summary>
		/// Apply Hash Password
		/// </summary>
		/// <param name="user">User</param>
		/// <param name="hashPassword">Hash password</param>
		/// <param name="saltPassword">Salt password</param>
		/// <returns>User</returns>
		public static User ApplyHashPassword(User user,
			HashPassword hashPassword,
			SaltPassword saltPassword)
		{
			return new User(user.UserId,
				user.LoginId,
				user.UserName,
				user.Password,
				hashPassword,
				saltPassword,
				user.WithdrawalStatus,
				user.DateCreated,
				user.DateChanged);
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
				new Password(AsString: string.Empty),
				new HashPassword(AsString: dto.HashPassword),
				new SaltPassword(AsString: dto.SaltPassword),
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
				this.HashPassword.AsString,
				this.SaltPassword.AsString,
				this.WithdrawalStatus.ToDbValue(),
				this.DateCreated.AsDateTime,
				this.DateChanged.AsDateTime);
		}

		/// <summary>
		/// Can login user
		/// </summary>
		/// <returns>True: user can login.</returns>
		public bool CanLogin()
		{
			if (this.LoginId is null || this.WithdrawalStatus.IsCanceled()) return false;

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
		/// <summary>Password</summary>
		public HashPassword HashPassword { get; }
		/// <summary>Password</summary>
		public SaltPassword SaltPassword { get; }
		/// <summary>Cancel flag</summary>
		public UsersWithdrawalStatus WithdrawalStatus { get; }
		/// <summary>DateCreated</summary>
		public DateCreated DateCreated { get; }
		/// <summary>Date changed</summary>
		public DateChanged DateChanged { get; }
	}
}
