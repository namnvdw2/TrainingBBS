// (c) 2025 W2 Co.,Ltd.

using System;
using w2.Common.Helper.Attribute;
using w2.ForumDomain.Domains.Forums;
using w2.FoundationDomain.Helpers;

namespace w2.ForumDomain.Dto.ForumRes
{
	/// <summary>
	/// Forum response dto
	/// </summary>
	public sealed class ForumResDto : IHashtableGeneratable
	{
		/// <summary>
		/// Contructor
		/// </summary>
		public ForumResDto()
		{
			this.ForumId = 0;
			this.ResponseId = 0;
			this.UserId = 0;
			this.UserName = string.Empty;
			this.ForumTitle = string.Empty;
			this.ForumText = string.Empty;
			this.DeleteFlg = ForumDeleteFlagStatus.Active.ToDbValue();
			this.DateCreated = DateTime.MinValue;
			this.DateChanged = DateTime.MinValue;
		}

		/// <summary>Forum id</summary>
		[HashtableAlias("forum_id")]
		public int ForumId { get; set; }
		/// <summary>Forum id</summary>
		[HashtableAlias("res_id")]
		public int ResponseId { get; set; }
		/// <summary>User id</summary>
		[HashtableAlias("user_id")]
		public int UserId { get; set; }
		/// <summary>User name</summary>
		[HashtableAlias("user_name")]
		public string UserName { get; set; }
		/// <summary>Forum title</summary>
		[HashtableAlias("forum_title")]
		public string ForumTitle { get; set; }
		/// <summary>Forum text</summary>
		[HashtableAlias("forum_text")]
		public string ForumText { get; set; }
		/// <summary>Delete flag</summary>
		[HashtableAlias("delete_flg")]
		public string DeleteFlg { get; set; }
		/// <summary>Date created</summary>
		[HashtableAlias("date_created")]
		public DateTime DateCreated { get; set; }
		/// <summary>Date changed</summary>
		[HashtableAlias("date_changed")]
		public DateTime DateChanged { get; set; }
	}
}
