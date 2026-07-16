// (c) 2026 W2 Co.,Ltd.

using w2.ForumDomain.Domains.Forums;
using w2.WebFrontDomain.Dto;
using w2.WebFrontDomain.Dto.Forums;
using static w2.WebFrontDomain.Validator.CommonMessages;

namespace w2.WebFrontDomain.Validator.Forums
{
	/// <summary>
	/// Forum validator
	/// </summary>
	public sealed class ForumValidator
	{
		/// <summary>Maximum length for forum tile</summary>
		protected const int MAX_LENGTH_FORUM_TITLE = 15;
		/// <summary>Maximum length for forum text</summary>
		protected const int MAX_LENGTH_FORUM_TEXT = 50;
		/// <summary>Error key for forum tile</summary>
		protected const string FORUM_TITLE_ERROR_KEY = "title";
		/// <summary>Error key for forum text</summary>
		protected const string FORUM_TEXT_ERROR_KEY = "content";
		/// <summary>Forum tile field name</summary>
		internal const string FORUM_TITLE_FIELD_NAME = "タイトル";
		/// <summary>Forum text field name</summary>
		internal const string FORUM_TEXT_FIELD_NAME = "内容";

		/// <summary>
		/// Validate
		/// </summary>
		/// <param name="request">Post forum request</param>
		/// <returns>Forum response</returns>
		public static ForumResponse Validate(PostForumRequest request)
		{
			ForumResponse response = ResponseFactory.Success<ForumResponse>();

			var titleErrorMessage = CheckTitle(request.Title);
			if (!string.IsNullOrEmpty(titleErrorMessage))
			{
				response.AddError(
					FORUM_TITLE_ERROR_KEY,
					titleErrorMessage);
			}

			var contentErrorMessage = CheckText(request.Content);
			if (!string.IsNullOrEmpty(contentErrorMessage))
			{
				response.AddError(
					FORUM_TEXT_ERROR_KEY,
					contentErrorMessage);
			}

			return response;
		}

		/// <summary>
		/// Check assess
		/// </summary>
		/// <param name="userId">User id</param>
		/// <param name="forum">Forum</param>
		/// <returns>Forum response</returns>
		public static ForumResponse CheckAssess(
			int userId,
			Forum forum)
		{
			ForumResponse response = ResponseFactory.Success<ForumResponse>();
			if (!forum.CanAccess(new ForumUserId(userId)))
			{
				response.Message = GetMessage(CommonMessageKey.ErrorCannotAccess);
				response.Success = false;
			}

			return response;
		}

		/// <summary>
		/// Check title
		/// </summary>
		/// <param name="title">Title</param>
		/// <returns>Error message</returns>
		public static string CheckTitle(string? title)
		{
			if (ValidatorUtility.CheckRequired(title))
			{
				return GetMessage(
					CommonMessageKey.FormatErrorRequired,
					FORUM_TITLE_FIELD_NAME);
			}

			if (ValidatorUtility.CheckMaxLength(title, MAX_LENGTH_FORUM_TITLE))
			{
				return GetMessage(
					CommonMessageKey.FormatErrorMaxLength,
					FORUM_TITLE_FIELD_NAME,
					MAX_LENGTH_FORUM_TITLE.ToString());
			}

			return string.Empty;
		}

		/// <summary>
		/// Check text
		/// </summary>
		/// <param name="text">Text</param>
		/// <returns>Error message</returns>
		public static string CheckText(string? text)
		{
			if (ValidatorUtility.CheckRequired(text))
			{
				return GetMessage(
					CommonMessageKey.FormatErrorRequired,
					FORUM_TEXT_FIELD_NAME);
			}

			if (ValidatorUtility.CheckMaxLength(text, MAX_LENGTH_FORUM_TEXT))
			{
				return GetMessage(
					CommonMessageKey.FormatErrorMaxLength,
					FORUM_TEXT_FIELD_NAME,
					MAX_LENGTH_FORUM_TEXT.ToString());
			}

			return string.Empty;
		}
	}
}
