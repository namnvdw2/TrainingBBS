// (c) 2026 W2 Co.,Ltd.

using Humanizer;
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
			ForumDeleteFlagStatus deleteFlag,
			DateCreated dateCreated,
			DateChanged dateChanged)
		{
			this.ForumId = forumId;
			this.UserId = userId;
			this.Title = title;
			this.Text = text;
			this.DeleteFlag = deleteFlag;
			this.UserName = new ForumUserName(string.Empty);
			this.DateCreated = dateCreated;
			this.DateChanged = dateChanged;
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
				ForumDeleteFlagStatus.Active,
				new DateCreated(DateTime.MinValue),
				new DateChanged(DateTime.MinValue))
		{
		}

		/// <summary>
		/// Creates a forum from a DTO
		/// </summary>
		/// <param name="dto">The forum DTO</param>
		/// <returns>Forum</returns>
		public static Forum CreateByDto(ForumDto dto)
		{
			var forum = new Forum(
				new ForumId(dto.ForumId),
				new ForumUserId(dto.UserId),
				new ForumTitle(dto.ForumTitle),
				new ForumText(dto.ForumText),
				DbValueAttribute.ParseToEnum<ForumDeleteFlagStatus>(dto.DeleteFlg),
				new DateCreated(dto.DateCreated),
				new DateChanged(dto.DateChanged))
			{
				UserName = new ForumUserName(dto.UserName),
			};

			return forum;
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
		public bool CanAccess(ForumUserId userId)
		{
			return userId == this.UserId;
		}

		/// <summary>Forum ID</summary>
		public ForumId ForumId { get; init; }
		/// <summary>Forum user ID</summary>
		public ForumUserId UserId { get; init; }
		/// <summary>Forum title</summary>
		public ForumTitle Title { get; init; }
		/// <summary>Forum text</summary>
		public ForumText Text { get; init; }
		/// <summary>Delete flag</summary>
		public ForumDeleteFlagStatus DeleteFlag { get; init; }
		/// <summary>Date changed</summary>
		public DateChanged DateChanged { get; init; }
		/// <summary>Date created</summary>
		public DateCreated DateCreated { get; init; }
		/// <summary>User name</summary>
		public ForumUserName UserName { get; init; }
	}
}
