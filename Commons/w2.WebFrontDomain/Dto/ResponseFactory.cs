// (c) 2026 W2 Co.,Ltd.

namespace w2.WebFrontDomain.Dto
{
	/// <summary>
	/// Response factory
	/// </summary>
	public static class ResponseFactory
	{
		/// <summary>
		/// Success
		/// </summary>
		/// <param name="nextUrl">Next url</param>
		/// <returns>Success response as BaseResponse</returns>
		public static BaseResponse Success(string? nextUrl = "")
		{
			return new BaseResponse
			{
				Success = true,
				RedirectUrl = nextUrl ?? string.Empty
			};
		}

		/// <summary>
		/// Error
		/// </summary>
		/// <param name="nextUrl">Next url</param>
		/// <returns>Error response as BaseResponse</returns>
		public static BaseResponse Error(string? nextUrl = "")
		{
			return new BaseResponse
			{
				Success = false,
				RedirectUrl = nextUrl ?? string.Empty
			};
		}

		/// <summary>
		/// Success
		/// </summary>
		/// <param name="nextUrl">Next url</param>
		/// <returns>Success response as T</returns>
		public static T Success<T>(string? nextUrl = "")
			where T : BaseResponse, new()
		{
			return new T
			{
				Success = true,
				RedirectUrl = nextUrl ?? string.Empty
			};
		}

		/// <summary>
		/// Error
		/// </summary>
		/// <param name="nextUrl">Next url</param>
		/// <returns>Error response as T</returns>
		public static T Error<T>(string? nextUrl = "")
			where T : BaseResponse, new()
		{
			return new T
			{
				Success = false,
				RedirectUrl = nextUrl ?? string.Empty
			};
		}
	}
}
