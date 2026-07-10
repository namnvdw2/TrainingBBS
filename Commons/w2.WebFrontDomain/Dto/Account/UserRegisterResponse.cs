// (c) 2025 W2 Co.,Ltd.

using System;
using w2.AccountDomain.Domains.Account;

namespace w2.WebFrontDomain.Dto.Account
{
	/// <summary>
	/// User register response
	/// </summary>
	[Serializable]
	public sealed class UserRegisterResponse : BaseResponse<AccountDomain.Domains.Account.Account>
	{
		/// <summary>
		/// Creates a success response
		/// </summary>
		/// <returns>Login response</returns>
		public static UserRegisterResponse CreateSuccessResponse(string nextUrl = "")
		{
			return new UserRegisterResponse
			{
				Success = true,
				RedirectUrl = nextUrl,
			};
		}

		/// <summary>
		/// Creates a error response
		/// </summary>
		/// <returns>Login response</returns>
		public static UserRegisterResponse CreateErrorResponse(string nextUrl = "")
		{
			return new UserRegisterResponse
			{
				Success = false,
				RedirectUrl = nextUrl,
			};
		}
	}
}
