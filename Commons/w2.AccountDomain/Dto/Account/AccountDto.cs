// (c) 2025 W2 Co.,Ltd.

using System;
using w2.AccountDomain.Domains.Account;
using w2.Common.Helper.Attribute;
using w2.FoundationDomain.Helpers;

namespace w2.AccountDomain.Dto.Account
{
	/// <summary>
	/// Account Dto
	/// </summary>
	[Serializable]
	public sealed class AccountDto : IHashtableGeneratable
	{
		/// <summary>Id</summary>
		[HashtableIgnore]
		[HashtableAlias("id")]
		public int Id { get; set; }
		/// <summary>LoginId</summary>
		[HashtableAlias("login_id")]
		public string LoginId { get; set; } = null!;
		/// <summary>Name</summary>
		[HashtableAlias("name")]
		public string Name { get; set; } = null!;
		/// <summary>Password</summary>
		[HashtableAlias("password")]
		public string Password { get; set; } = null!;
		/// <summary>Delete flag</summary>
		[HashtableAlias("delete_flg")]
		public string DeleteFlg { get; set; } = UserCancelStatus.Active.ToDbValue();
		/// <summary>Date created</summary>
		[HashtableAlias("date_created")]
		public DateTime DateCreated { get; set; } = DateTime.MinValue;
		/// <summary>Date changed</summary>
		[HashtableAlias("date_changed")]
		public DateTime DateChanged { get; set; } = DateTime.MinValue;
	}
}
