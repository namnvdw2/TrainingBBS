// (c) 2026 W2 Co.,Ltd.

using System;
using w2.Common.Helper.Attribute;
using w2.ForumDomain.Domains.Forums;
using w2.ForumDomain.Dto.ForumRes;

namespace w2.ForumDomain.Domains.ForumRes
{
	/// <summary>
	/// Forum response
	/// </summary>
	public sealed class ForumRes
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="resForumId">Response forum id</param>
		/// <param name="forumId">The forum id</param>
		/// <param name="userId">The user id</param>
		/// <param name="userName">The user name</param>
		/// <param name="title">The title</param>
		/// <param name="text">The text</param>
		/// <param name="deleteFlag">The delete flag</param>
		public ForumRes(
			ResForumId resForumId,
			ForumId forumId,
			ForumUserId userId,
			ForumUserName userName,
			ForumTitle title,
			ForumText text,
			ForumDeleteFlagStatus deleteFlag,
			DateCreated dateCreated,
			DateChanged dateChanged)
		{
			this.ResForumId = resForumId;
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
		/// <param name="forumId">Forum id</param>
		/// <param name="userId">The user id</param>
		/// <param name="title">The title</param>
		/// <param name="text">The text</param>
		public ForumRes(
			ForumId forumId,
			ForumUserId userId,
			ForumTitle title,
			ForumText text)
			: this(
				new ResForumId(AsInt: 0),
				forumId,
				userId,
				new ForumUserName(AsString: string.Empty),
				title,
				text,
				ForumDeleteFlagStatus.Active,
				new DateCreated(AsDateTime: DateTime.MinValue),
				new DateChanged(AsDateTime: DateTime.MinValue))
		{
		}

		/// <summary>
		/// Creates a ForumRes from a DTO
		/// </summary>
		/// <param name="dto">The forum DTO</param>
		/// <returns>Forum</returns>
		internal static ForumRes CreateByDto(ForumResDto dto)
		{
			var forumRes = new ForumRes(
				new ResForumId(AsInt: dto.ResponseId),
				new ForumId(AsInt: dto.ForumId),
				new ForumUserId(AsInt: dto.UserId),
				new ForumUserName(AsString: dto.UserName),
				new ForumTitle(AsString: dto.ResponseTitle),
				new ForumText(AsString: dto.ResponseText),
				DbValueAttribute.ParseToEnum<ForumDeleteFlagStatus>(dto.DeleteFlg),
				new DateCreated(AsDateTime: dto.DateCreated),
				new DateChanged(AsDateTime: dto.DateChanged));

			return forumRes;
		}

		/// <summary>
		/// Convert to DTO
		/// </summary>
		/// <returns>Forum DTO</returns>
		internal ForumResDto CreateDto()
		{
			var dto = new ForumResDto
			{
				ResponseId = this.ResForumId.AsInt,
				ForumId = this.ForumId.AsInt,
				UserId = this.UserId.AsInt,
				ResponseTitle = this.Title.AsString,
				ResponseText = this.Text.AsString,
				DeleteFlg = this.DeleteFlag.ToDbValue(),
				DateCreated = this.DateCreated.AsDateTime,
				DateChanged = this.DateChanged.AsDateTime,
			};

			return dto;
		}

		/// <summary>Response forum id</summary>
		public ResForumId ResForumId { get; }
		/// <summary>Forum id</summary>
		public ForumId ForumId { get; }
		/// <summary>Forum user id</summary>
		public ForumUserId UserId { get; }
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
		public ForumUserName UserName { get; }
	}
}
