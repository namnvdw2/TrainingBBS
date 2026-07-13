// (c) 2026 W2 Co.,Ltd.

using w2.AccountDomain.Domains.Account;
using w2.AccountDomain.Services.Account;
using w2.WebFrontDomain.Dto;
using w2.WebFrontDomain.Dto.Account;
using static w2.WebFrontDomain.Validator.CommonMessages;

namespace w2.WebFrontDomain.Validator.Accounts
{
	/// <summary>
	/// Account register validator
	/// </summary>
	public class AccountRegisterValidator : AccountValidator
	{
		/// <summary>
		/// Register validate
		/// </summary>
		/// <param name="request">Account register request</param>
		/// <param name="accountService">Account service</param>
		/// <returns>Account Register response</returns>
		public static AccountRegisterModifyResponse RegisterValidate(
			AccountRegisterModifyRequest request,
			AccountService accountService)
		{
			var response = DataValidate(request);

			if (response.HasError) return response;

			if (accountService.GetByLoginId(new LoginId(request.LoginId)) is not null)
			{
				response.AddError(
					LOGIN_ID_ERROR_KEY,
					GetMessage(CommonMessageKey.ErrorLoginIdUsed));

				return response;
			}

			return response;
		}

		/// <summary>
		/// Date validate
		/// </summary>
		/// <param name="request">Account register modify request</param>
		/// <returns>Account register modify response</returns>
		public static AccountRegisterModifyResponse DataValidate(AccountRegisterModifyRequest request)
		{
			var response = ResponseFactory.Success<AccountRegisterModifyResponse>(request?.NextUrl);
			var loginIdErrorMessage = AccountValidator.CheckLoginId(request?.LoginId);
			if (!string.IsNullOrEmpty(loginIdErrorMessage))
			{
				response.AddError(
					LOGIN_ID_ERROR_KEY,
					loginIdErrorMessage);
			}

			var passwordErrorMessage = AccountValidator.CheckPassword(request?.Password);
			if (!string.IsNullOrEmpty(passwordErrorMessage))
			{
				response.AddError(
					PASSWORD_ERROR_KEY,
					passwordErrorMessage);
			}

			var userNameErrorMessage = CheckName(request?.Name);
			if (!string.IsNullOrEmpty(userNameErrorMessage))
			{
				response.AddError(
					USER_NAME_ERROR_KEY,
					userNameErrorMessage);
			}

			response.ResponseObject = new Account
			{
				LoginId = new LoginId(request?.LoginId ?? string.Empty),
				Name = new Name(request?.Name ?? string.Empty),
				Password = Password.FromPlainText(request?.Password ?? string.Empty),
			};

			return response;
		}
	}
}
