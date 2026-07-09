// (c) 2025 W2 Co.,Ltd.

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

		public Forum()
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
			};

			return dto;
		}

		/// <summary>Forum ID</summary>
		public ForumId ForumId { get; }
		/// <summary>Forum user ID</summary>
		public ForumUserId UserId { get; }
		/// <summary>Forum title</summary>
		public ForumTitle Title { get; }
		/// <summary>Forum text</summary>
		public ForumText Text { get; }
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
