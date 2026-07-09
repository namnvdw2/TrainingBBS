// (c) 2025 W2 Co.,Ltd.
using w2.ForumDomain.Domains.Forums;

namespace w2.WebFrontDomain.Dto.Forums
{
	/// <summary>
	/// Forum pagination response
	/// </summary>
	public class ForumPaginationResponse : BaseResponse<PaginationResponseObject<ForumResponse>>
	{
		/// <summary>
		/// Creates a success response
		/// </summary>
		/// <returns>Login response</returns>
		public static ForumPaginationResponse CreateSuccessResponse(string nextUrl = "")
		{
			return new ForumPaginationResponse
			{
				Success = true,
				RedirectUrl = nextUrl,
			};
		}

		/// <summary>
		/// Creates a error response
		/// </summary>
		/// <returns>Login response</returns>
		public static ForumPaginationResponse CreateErrorResponse(string nextUrl = "")
		{
			return new ForumPaginationResponse
			{
				Success = false,
				RedirectUrl = nextUrl,
			};
		}
	}
}
