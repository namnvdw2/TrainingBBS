// (c) 2025 W2 Co.,Ltd.

using w2.WebFrontDomain.Configurations;

namespace w2.WebFrontDomain.Dto.Account
{
	/// <summary>
	/// Login response
	/// </summary>
	public sealed class LoginResponse : BaseResponse
	{
		/// <summary>
		/// Creates a success response
		/// </summary>
		/// <returns>Login response</returns>
		public static LoginResponse CreateSuccessResponse(string? nextUrl = null)
		{
			return new LoginResponse
			{
				Success = true,
				RedirectUrl = nextUrl ?? ConstantsPage.TopForumPageUrl,
			};
		}
	}
}
