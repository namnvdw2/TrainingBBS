// (c) 2025 W2 Co.,Ltd.

using SessionDomain.Dto.User;
using System.Diagnostics.CodeAnalysis;
using w2.AccountDomain.Services.Account;
using w2.WebFrontDomain.Dto.Account;
using w2.WebFrontDomain.Validator.User;
using static w2.WebFrontDomain.Validator.CommonMessages;

namespace w2.WebFrontDomain.Validator
{
	/// <summary>
	/// Login validator
	/// </summary>
	public class LoginValidator : UserValidator
	{
		/// <summary>
		/// Validate
		/// </summary>
		/// <param name="request"></param>
		/// <param name="accountService"></param>
		/// <param name="resultUser"></param>
		/// <returns>Login response</returns>
		public static LoginResponse Validate(
			LoginRequest request,
			AccountService accountService,
			[NotNullWhen(returnValue: true)] out LoginUser? resultUser)
		{
			var response = new LoginResponse();
			var user = accountService.GetByLoginId(new AccountDomain.Domains.Account.LoginId (request.LoginId));
			if (user == null
				|| !user.CanLogin(new AccountDomain.Domains.Account.Password(request.Password)))
			{
				response.Success = false;
				response.Message = GetMessage(CommonMessageKey.ErrorLoginIdOrPasswordInvalid);
				resultUser = null;
				return response;
			}

			resultUser = LoginUser.CreateByUser(user);
			return new LoginResponse
			{
				Success = true
			};
		}
	}
}
