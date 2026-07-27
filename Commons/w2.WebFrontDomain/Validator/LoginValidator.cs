// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Dto.Users;
using System.Diagnostics.CodeAnalysis;
using w2.AccountDomain.Domains.Users;
using w2.AccountDomain.Services.Users;
using w2.WebFrontDomain.Dto;
using w2.WebFrontDomain.Dto.Users;
using w2.WebFrontDomain.Interface;
using w2.WebFrontDomain.Validator.Users;
using static w2.WebFrontDomain.Validator.CommonMessages;

namespace w2.WebFrontDomain.Validator
{
	/// <summary>
	/// Login validator
	/// </summary>
	public sealed class LoginValidator : UserValidator, ILoginValidator
	{
		/// <inheritdoc />
		public LoginResponse Validate(
			LoginRequest? request,
			UserService userService,
			[NotNullWhen(returnValue: true)] out LoginUser? resultUser)
		{
			var response = ResponseFactory.Success<LoginResponse>(request?.NextUrl);
			var user = userService.GetByLoginId(new LoginId(request?.LoginId ?? string.Empty));
			if (user is null
				|| !user.CanLogin(Password.FromPlainText(request?.Password ?? string.Empty)))
			{
				response.Success = false;
				response.Message = GetMessage(CommonMessageKey.ErrorLoginIdOrPasswordInvalid);
				resultUser = null;
				return response;
			}

			resultUser = LoginUser.CreateByUser(user);
			return response;
		}
	}
}
