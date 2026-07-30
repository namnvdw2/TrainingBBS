// (c) 2026 W2 Co.,Ltd.

using w2.AccountDomain.Domains.Users;
using w2.AccountDomain.Services.Users;
using w2.WebFrontDomain.Dto;
using w2.WebFrontDomain.Dto.Users;
using w2.WebFrontDomain.Interface;
using static w2.WebFrontDomain.Validator.CommonMessages;

namespace w2.WebFrontDomain.Validator.Users
{
	/// <summary>
	/// User register validator
	/// </summary>
	public sealed class UserRegisterValidator : UserValidator, IUserRegisterValidator
	{
		/// <inheritdoc />
		public UserRegisterModifyResponse ValidateRegisterData(
			UserRegisterModifyRequest request,
			UserService userService)
		{
			var response = ValidateUserData(request);

			if (response.HasError) return response;

			if (userService.GetByLoginId(new LoginId(request.LoginId)) is not null)
			{
				response.AddError(
					LOGIN_ID_ERROR_KEY,
					GetMessage(CommonMessageKey.ErrorLoginIdUsed));

				return response;
			}

			return response;
		}

		/// <inheritdoc />
		public UserRegisterModifyResponse ValidateUserData(UserRegisterModifyRequest request)
		{
			var response = ResponseFactory.Success<UserRegisterModifyResponse>(request.NextUrl);
			var loginIdErrorMessage = UserValidator.CheckLoginId(request.LoginId);
			if (!string.IsNullOrEmpty(loginIdErrorMessage))
			{
				response.AddError(
					LOGIN_ID_ERROR_KEY,
					loginIdErrorMessage);
			}

			var passwordErrorMessage = UserValidator.CheckPassword(request.Password);
			if (!string.IsNullOrEmpty(passwordErrorMessage))
			{
				response.AddError(
					PASSWORD_ERROR_KEY,
					passwordErrorMessage);
			}

			var userNameErrorMessage = CheckName(request.Name);
			if (!string.IsNullOrEmpty(userNameErrorMessage))
			{
				response.AddError(
					USER_NAME_ERROR_KEY,
					userNameErrorMessage);
			}

			response.ResponseObject = User.CreateUserForModify(
				new LoginId(request.LoginId ?? string.Empty),
				new UserName(request.Name ?? string.Empty),
				Password.CreateNew(request.Password ?? string.Empty));

			return response;
		}
	}
}
