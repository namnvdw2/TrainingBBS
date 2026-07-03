// (c) 2025 W2 Co.,Ltd.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w2.Common.Helper.Attribute;
using w2.ForumDomain.Dto.Forum;

namespace w2.ForumDomain.Domains.Forum
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
				DateChanged = new DateChanged(dto.DateChanged),
				UserName = new ForumUserName(dto.UserName),
			};

			return model;
		}

		/// <summary>
		/// Convert to DTO
		/// </summary>
		/// <returns>Forum DTO</returns>
		internal ForumDto ToDto()
		{
			var dto = new ForumDto
			{
				ForumId = this.ForumId.AsInt,
				UserId = this.UserId.AsInt,
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
		/// <summary>User name</summary>
		public ForumUserName UserName { get; set; } = new ForumUserName(string.Empty);
	}
}
