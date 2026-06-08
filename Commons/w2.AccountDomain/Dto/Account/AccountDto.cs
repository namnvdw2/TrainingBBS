// (c) 2025 W2 Co.,Ltd.

using System;
using w2.FoundationDomain.Helpers;

namespace w2.AccountDomain.Dto.Account
{
	/// <summary>
	/// Account Dto
	/// </summary>
	public sealed class AccountDto : IHashtableGeneratable
	{
		/// <summary>Id</summary>
		[HashtableAlias("id")]
		public string Id { get; set; } = null!;
		/// <summary>LoginId</summary>
		[HashtableAlias("loginId")]
		public string LoginId { get; set; } = null!;
		/// <summary>Name</summary>
		[HashtableAlias("name")]
		public string Name { get; set; } = null!;
		/// <summary>Password</summary>
		[HashtableAlias("password")]
		public string Password { get; set; } = null!;
		/// <summary>Delete flag</summary>
		[HashtableAlias("delete_flg")]
		public string DeleteFlg { get; set; } = null!;
		/// <summary>Date created</summary>
		[HashtableAlias("date_created")]
		public DateTime DateCreated { get; set; }
		/// <summary>Date changed</summary>
		[HashtableAlias("date_changed")]
		public DateTime DateChanged { get; set; }
	}
}
