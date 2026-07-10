// (c) 2025 W2 Co.,Ltd.

using w2.ForumDomain.Domains.Forums;

namespace w2.WebFrontDomain.Dto.Forums
{
	/// <summary>
	/// Forum response
	/// </summary>
	public sealed class ForumResponse : BaseResponse<Forum>
	{
		/// <summary>
		/// Creates a success response
		/// </summary>
		/// <returns>Login response</returns>
		public static ForumResponse CreateSuccessResponse(string nextUrl = "")
		{
			return new ForumResponse
			{
				Success = true,
				RedirectUrl = nextUrl,
			};
		}

		/// <summary>
		/// Creates a error response
		/// </summary>
		/// <returns>Login response</returns>
		public static ForumResponse CreateErrorResponse(string nextUrl = "")
		{
			return new ForumResponse
			{
				Success = false,
				RedirectUrl = nextUrl,
			};
		}
	}
}
