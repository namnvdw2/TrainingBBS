// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Dto.Users;
using System.Diagnostics.CodeAnalysis;
using w2.AccountDomain.Domains.Users;
using w2.AccountDomain.Services.Users;
using w2.WebFrontDomain.Dto;
using w2.WebFrontDomain.Dto.Users;
using w2.WebFrontDomain.Helper;
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
			resultUser = null;
			var response = ResponseFactory.Success<LoginResponse>(request?.NextUrl);
			var error = CheckLoginId(request?.LoginId);

			if (error != string.Empty)
			{
				response.AddError(nameof(request.LoginId), error);

				return response;
			}

			var user = userService.GetByLoginId(new LoginId(request?.LoginId ?? string.Empty));
			if (user is null
				|| !user.CanLogin()
				|| !HashUtility.Verify(request?.Password ?? string.Empty, user.HashPassword.AsString, user.SaltPassword.AsString))
			{
				response.Success = false;
				response.Message = GetMessage(CommonMessageKey.ErrorLoginIdOrPasswordInvalid);

				return response;
			}

			resultUser = LoginUser.CreateByUser(user);

			return response;
		}
	}
}
