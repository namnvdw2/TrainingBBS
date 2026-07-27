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
		/// <param name="password">Password</param>
		/// <param name="withdrawalStatus">Users withdrawal statu</param>
		/// <param name="dateCreated">DateCreated</param>
		/// <param name="dateChanged">DateChanged</param>
		public UserDto(int id,
			string loginId,
			string userName,
			string password,
			string withdrawalStatus,
			DateTime dateCreated,
			DateTime dateChanged)
		{
			this.Id = id;
			this.LoginId = loginId;
			this.UserName = userName;
			this.Password = password;
			this.WithdrawalStatus = withdrawalStatus;
			this.DateCreated = dateCreated;
			this.DateChanged = dateChanged;
		}
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="id">id</param>
		/// <param name="loginId">Login id</param>
		/// <param name="userName">Name</param>
		/// <param name="password">Password</param>
		public UserDto(int id,
			string loginId,
			string userName,
			string password)
		{
			this.Id = id;
			this.LoginId = loginId;
			this.UserName = userName;
			this.Password = password;
			this.WithdrawalStatus = UsersWithdrawalStatus.Active.ToDbValue();
			this.DateCreated = DateTime.MinValue;
			this.DateChanged = DateTime.MinValue;
		}
		/// <summary>
		/// Constructor
		/// </summary>
		public UserDto()
		{
			this.Id = int.MinValue;
			this.LoginId = string.Empty;
			this.UserName = string.Empty;
			this.Password = string.Empty;
			this.WithdrawalStatus = UsersWithdrawalStatus.Active.ToDbValue();
			this.DateCreated = DateTime.MinValue;
			this.DateChanged = DateTime.MinValue;
		}

		/// <summary>Id</summary>
		[HashtableIgnore]
		[HashtableAlias("id")]
		public int Id { get; set; }
		/// <summary>LoginId</summary>
		[HashtableAlias("login_id")]
		public string LoginId { get; set; }
		/// <summary>User name</summary>
		[HashtableAlias("name")]
		public string UserName { get; set; }
		/// <summary>Password</summary>
		[HashtableAlias("password")]
		public string Password { get; set; }
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
