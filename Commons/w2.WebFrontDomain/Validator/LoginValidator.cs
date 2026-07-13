// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Dto.Accounts;
using System.Diagnostics.CodeAnalysis;
using w2.AccountDomain.Domains.Account;
using w2.AccountDomain.Services.Account;
using w2.WebFrontDomain.Dto;
using w2.WebFrontDomain.Dto.Account;
using w2.WebFrontDomain.Validator.Accounts;
using static w2.WebFrontDomain.Validator.CommonMessages;

namespace w2.WebFrontDomain.Validator
{
	/// <summary>
	/// Login validator
	/// </summary>
	public class LoginValidator : AccountValidator
	{
		/// <summary>
		/// Validate
		/// </summary>
		/// <param name="request"></param>
		/// <param name="accountService"></param>
		/// <param name="resultUser"></param>
		/// <returns>Login response</returns>
		public static LoginResponse Validate(
			LoginRequest? request,
			AccountService accountService,
			[NotNullWhen(returnValue: true)] out LoginAccount? resultUser)
		{
			var response = ResponseFactory.Success<LoginResponse>(request?.NextUrl);
			var user = accountService.GetByLoginId(new AccountDomain.Domains.Account.LoginId(request?.LoginId ?? string.Empty));
			if (user == null
				|| !user.CanLogin(Password.FromPlainText(request?.Password ?? string.Empty)))
			{
				response.Success = false;
				response.Message = GetMessage(CommonMessageKey.ErrorLoginIdOrPasswordInvalid);
				resultUser = null;
				return response;
			}

			resultUser = LoginAccount.CreateByUser(user);
			return response;
		}
	}
}
