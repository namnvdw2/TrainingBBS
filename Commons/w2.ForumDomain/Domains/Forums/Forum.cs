// (c) 2026 W2 Co.,Ltd.

using System;
using w2.Common.Helper.Attribute;
using w2.ForumDomain.Dto.Forums;

namespace w2.ForumDomain.Domains.Forums
{
	/// <summary>
	/// Forum
	/// </summary>
	public sealed class Forum
	{
		/// <summary>
		/// Contructor
		/// </summary>
		/// <param name="forumId">The forum id</param>
		/// <param name="userId">The user id</param>
		/// <param name="title">The title</param>
		/// <param name="text">The text</param>
		/// <param name="deleteFlag">The delete flag</param>
		public Forum(
			ForumId forumId,
			ForumUserId userId,
			ForumTitle title,
			ForumText text,
			ForumDeleteFlagStatus deleteFlag)
		{
			this.ForumId = forumId;
			this.UserId = userId;
			this.Title = title;
			this.Text = text;
			this.DeleteFlag = deleteFlag;
		}
		/// <summary>
		/// Contructor
		/// </summary>
		/// <param name="userId">The user id</param>
		/// <param name="title">The title</param>
		/// <param name="text">The text</param>
		public Forum(
			ForumUserId userId,
			ForumTitle title,
			ForumText text)
			: this(
				new ForumId(AsInt: 0),
				userId,
				title,
				text,
				ForumDeleteFlagStatus.Active)
		{
		}

		/// <summary>
		/// Creates a model from a DTO
		/// </summary>
		/// <param name="dto">The forum DTO</param>
		/// <returns>Forum model</returns>
		public static Forum CreateByDto(ForumDto dto)
		{
			var model = new Forum(
				new ForumId(dto.ForumId),
				new ForumUserId(dto.UserId),
				new ForumTitle(dto.ForumTitle),
				new ForumText(dto.ForumText),
				DbValueAttribute.ParseToEnum<ForumDeleteFlagStatus>(dto.DeleteFlg))
			{
				DateCreated = new DateCreated(dto.DateCreated),
				DateChanged = new DateChanged(dto.DateChanged),
				UserName = new ForumUserName(dto.UserName),
			};

			return model;
		}

		/// <summary>
		/// Convert to DTO
		/// </summary>
		/// <returns>Forum DTO</returns>
		internal ForumDto CreateDto()
		{
			var dto = new ForumDto
			{
				ForumId = this.ForumId.AsInt,
				UserId = this.UserId.AsInt,
				UserName = this.UserName.AsString,
				ForumTitle = this.Title.AsString,
				ForumText = this.Text.AsString,
				DeleteFlg = this.DeleteFlag.ToDbValue(),
				DateCreated = this.DateCreated.AsDateTime,
				DateChanged = this.DateChanged.AsDateTime,
			};

			return dto;
		}

		/// <summary>
		/// Can access
		/// </summary>
		/// <param name="userId">userId</param>
		/// <returns>True if user id can update or delete, otherwise return false</returns>
		public bool CanAccess(int userId)
		{
			return userId == this.UserId.AsInt;
		}

		/// <summary>Forum ID</summary>
		public ForumId ForumId { get; }
		/// <summary>Forum user ID</summary>
		public ForumUserId UserId { get; }
		/// <summary>Forum title</summary>
		public ForumTitle Title { get; set; }
		/// <summary>Forum text</summary>
		public ForumText Text { get; set; }
		/// <summary>Delete flag</summary>
		public ForumDeleteFlagStatus DeleteFlag { get; }
		/// <summary>Date changed</summary>
		public DateChanged DateChanged { get; set; } = new DateChanged(DateTime.MinValue);
		/// <summary>Date created</summary>
		public DateCreated DateCreated { get; set; } = new DateCreated(DateTime.MinValue);
		/// <summary>User name</summary>
		public ForumUserName UserName { get; set; } = new ForumUserName(string.Empty);
	}
}
