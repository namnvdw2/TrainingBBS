// (c) 2025 W2 Co.,Ltd.

using Humanizer;
using w2.AccountDomain.Domains.Account;
using w2.AccountDomain.Dto.Account;
using w2.AccountDomain.Services.Account;
using w2.Common.Helper.Attribute;
using w2.WebFrontDomain.Dto.Account;
using static w2.WebFrontDomain.Validator.CommonMessages;

namespace w2.WebFrontDomain.Validator.User
{
	/// <summary>
	/// User register validator
	/// </summary>
	public class UserRegisterValidator : UserValidator
	{
		/// <summary>
		/// Validate
		/// </summary>
		/// <param name="request">User register request</param>
		/// <param name="accountService">Account service</param>
		/// <returns>User Register response</returns>
		public static UserRegisterResponse Validate(
			UserRegisterRequest request,
			AccountService accountService)
		{
			var response = new UserRegisterResponse();
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

			if (response.HasError) return response;

			if (accountService.GetByLoginId(new LoginId(request.LoginId)) is not null)
			{
				response.AddError(
					LOGIN_ID_ERROR_KEY,
					GetMessage(CommonMessageKey.ErrorLoginIdUsed));

				return response;
			}

			response.ResponseObject = new AccountDto
			{
				LoginId = request.LoginId,
				Name = request.Name,
				Password = request.Password,
			};

			return response;
		}
	}
}
