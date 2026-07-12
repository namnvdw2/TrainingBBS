// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Repositories;
using w2.AccountDomain.Services.Account;
using w2.WebFrontDomain.Configurations;
using w2.WebFrontDomain.Dto;
using w2.WebFrontDomain.Dto.Account;
using w2.WebFrontDomain.Validator;
using w2.WebFrontDomain.Validator.Accounts;

namespace w2.WebFrontDomain.Services.Account
{
	/// <summary>
	/// Login logout service
	/// </summary>
	public class LoginLogoutService
	{
		private readonly AccountService _accountService;
		private readonly LoginAccountSessionRepository _session;

		/// <summary>
		/// Constructor
		/// </summary>
		public LoginLogoutService(
			AccountService accountService,
			LoginAccountSessionRepository session)
		{
			_accountService = accountService;
			_session = session;
		}

		/// <summary>
		/// Login
		/// </summary>
		/// <param name="request">Login request</param>
		/// <returns>Login response</returns>
		public LoginResponse Login(LoginRequest request)
		{
			if (_session.ExistsLoggedIn()) return
					ResponseFactory.Success<LoginResponse>(request?.NextUrl);
			LoginResponse loginResponse = new LoginResponse();
			var error = AccountValidator.CheckLoginId(request.LoginId);
			if (error != string.Empty)
			{
				loginResponse.AddError(nameof(request.LoginId),error);
				return loginResponse;
			}

			var result = LoginValidator.Validate(request, _accountService, out var user);
			if (result.HasError || (user is null)) return (LoginResponse)result;

			_session.LoginAccount = user;
			return ResponseFactory.Success<LoginResponse>(request?.NextUrl);
		}

		/// <summary>
		/// Logout
		/// </summary>
		/// <returns></returns>
		public BaseResponse Logout()
		{
			_session.RemoveAllSession();
			return new BaseResponse()
			{
				RedirectUrl = ConstantsPage.LoginPageUrl
			};
		}
	}
}
