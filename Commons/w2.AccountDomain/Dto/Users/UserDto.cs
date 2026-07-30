// (c) 2026 W2 Co.,Ltd.

using System;
using w2.AccountDomain.Domains.Users;
using w2.Common.Helper.Attribute;
using w2.FoundationDomain.Helpers;

namespace w2.AccountDomain.Dto.Users
{
	/// <summary>
	/// User Dto
	/// </summary>
	[Serializable]
	internal sealed class UserDto : IHashtableGeneratable
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="id">Id</param>
		/// <param name="loginId">Login id</param>
		/// <param name="userName">Name</param>
		/// <param name="withdrawalStatus">Users withdrawal statu</param>
		/// <param name="dateCreated">DateCreated</param>
		/// <param name="dateChanged">DateChanged</param>
		/// <param name="hashPassword">Hash password</param>
		public UserDto(int id,
			string loginId,
			string userName,
			string withdrawalStatus,
			DateTime dateCreated,
			DateTime dateChanged,
			string hashPassword)
		{
			this.Id = id;
			this.LoginId = loginId;
			this.UserName = userName;
			this.HashPassword = hashPassword;
			this.WithdrawalStatus = withdrawalStatus;
			this.DateCreated = dateCreated;
			this.DateChanged = dateChanged;
		}
		/// <summary>
		/// Constructor
		/// </summary>
		public UserDto()
		{
			this.Id = int.MinValue;
			this.LoginId = string.Empty;
			this.UserName = string.Empty;
			this.HashPassword = string.Empty;
			this.WithdrawalStatus = UsersWithdrawalStatus.Active.ToDbValue();
			this.DateCreated = DateTime.MinValue;
			this.DateChanged = DateTime.MinValue;
		}

		/// <summary>Id</summary>
		[HashtableIgnore]
		public int Id { get; set; }
		/// <summary>LoginId</summary>
		[HashtableAlias("login_id")]
		public string LoginId { get; set; }
		/// <summary>User name</summary>
		[HashtableAlias("user_name")]
		public string UserName { get; set; }
		/// <summary>Hash password</summary>
		[HashtableAlias("hash_password")]
		public string HashPassword { get; set; }
		/// <summary>Users withdrawal status</summary>
		[HashtableAlias("delete_flg")]
		public string WithdrawalStatus { get; set; }
		/// <summary>Date created</summary>
		[HashtableAlias("date_created")]
		public DateTime DateCreated { get; set; }
		/// <summary>Date changed</summary>
		[HashtableAlias("date_changed")]
		public DateTime DateChanged { get; set; }
	}
}
