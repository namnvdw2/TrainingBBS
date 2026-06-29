// (c) 2025 W2 Co.,Ltd.

using w2.AccountDomain.Domains.Account;
using w2.WebFrontDomain.Configurations;

namespace w2.WebFrontDomain.Dto.Account
{
	/// <summary>
	/// User register response
	/// </summary>
	public sealed class UserRegisterResponse : BaseResponse<AccountModel>
	{
		/// <summary>
		/// Creates a success response
		/// </summary>
		/// <returns>Login response</returns>
		public static UserRegisterResponse CreateSuccessResponse(string? nextUrl = null)
		{
			return new UserRegisterResponse
			{
				Success = true,
				RedirectUrl = nextUrl ?? ConstantsPage.TopForumPageUrl,
			};
		}
	}
}
