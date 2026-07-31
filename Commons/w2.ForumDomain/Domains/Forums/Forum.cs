// (c) 2026 W2 Co.,Ltd.

using System;
using w2.AccountDomain.Domains.Users;
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
		/// Constructor
		/// </summary>
		/// <param name="forumId">The forum id</param>
		/// <param name="userId">The user id</param>
		/// <param name="userName">The user name</param>
		/// <param name="title">The title</param>
		/// <param name="text">The text</param>
		/// <param name="deleteFlag">The delete flag</param>
		/// <param name="dateCreated">Date created</param>
		/// <param name="dateChanged">Date changed</param>
		public Forum(
			ForumId forumId,
			UserId userId,
			UserName userName,
			ForumTitle title,
			ForumText text,
			ForumDeleteFlagStatus deleteFlag,
			DateCreated dateCreated,
			DateChanged dateChanged)
		{
			this.ForumId = forumId;
			this.UserId = userId;
			this.UserName = userName;
			this.Title = title;
			this.Text = text;
			this.DeleteFlag = deleteFlag;
			this.DateCreated = dateCreated;
			this.DateChanged = dateChanged;
		}
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="userId">The user id</param>
		/// <param name="title">The title</param>
		/// <param name="text">The text</param>
		public Forum(
			UserId userId,
			ForumTitle title,
			ForumText text)
			: this(
				new ForumId(AsInt: 0),
				userId,
				new UserName(AsString: string.Empty),
				title,
				text,
				ForumDeleteFlagStatus.Active,
				new DateCreated(AsDateTime: DateTime.MinValue),
				new DateChanged(AsDateTime: DateTime.MinValue))
		{
		}

		/// <summary>
		/// Creates a forum from a DTO
		/// </summary>
		/// <param name="dto">The forum DTO</param>
		/// <returns>Forum</returns>
		internal static Forum CreateByDto(ForumDto dto)
		{
			var forum = new Forum(
				new ForumId(dto.ForumId),
				new UserId(dto.UserId),
				new UserName(dto.UserName),
				new ForumTitle(dto.ForumTitle),
				new ForumText(dto.ForumText),
				DbValueAttribute.ParseToEnum<ForumDeleteFlagStatus>(dto.DeleteFlg),
				new DateCreated(dto.DateCreated),
				new DateChanged(dto.DateChanged));

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
		/// <param name="userId">User id</param>
		/// <returns>True if user id can update or delete, otherwise return false</returns>
		public bool CanAccess(UserId userId)
		{
			return userId == this.UserId;
		}

		/// <summary>Forum ID</summary>
		public ForumId ForumId { get; }
		/// <summary>Forum user ID</summary>
		public UserId UserId { get; }
		/// <summary>Forum title</summary>
		public ForumTitle Title { get; }
		/// <summary>Forum text</summary>
		public ForumText Text { get; }
		/// <summary>Delete flag</summary>
		public ForumDeleteFlagStatus DeleteFlag { get; }
		/// <summary>Date changed</summary>
		public DateChanged DateChanged { get; }
		/// <summary>Date created</summary>
		public DateCreated DateCreated { get; }
		/// <summary>User name</summary>
		public UserName UserName { get; }
	}
}
