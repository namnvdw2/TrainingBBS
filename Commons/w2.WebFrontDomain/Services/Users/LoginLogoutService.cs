// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Repositories;
using w2.AccountDomain.Services.Users;
using w2.WebFrontDomain.Configurations;
using w2.WebFrontDomain.Dto;
using w2.WebFrontDomain.Dto.Users;
using w2.WebFrontDomain.Validator;
using w2.WebFrontDomain.Validator.Users;

namespace w2.WebFrontDomain.Services.Users
{
	/// <summary>
	/// Login logout service
	/// </summary>
	public class LoginLogoutService
	{
		private readonly UserService _userService;
		private readonly LoginUserSessionRepository _session;

		/// <summary>
		/// Constructor
		/// </summary>
		public LoginLogoutService(
			UserService userService,
			LoginUserSessionRepository session)
		{
			_userService = userService;
			_session = session;
		}

		/// <summary>
		/// Login
		/// </summary>
		/// <param name="request">Login request</param>
		/// <returns>Login response</returns>
		public LoginResponse Login(LoginRequest request)
		{
			var nextUrl = !string.IsNullOrEmpty(request?.NextUrl)
				? request?.NextUrl
				: ConstantsPage.TopForumPageUrl;

			if (_session.ExistsLoggedIn()) return
					ResponseFactory.Success<LoginResponse>(nextUrl);
			LoginResponse loginResponse = new LoginResponse();
			var error = UserValidator.CheckLoginId(request?.LoginId);
			if (error != string.Empty)
			{
				loginResponse.AddError(nameof(request.LoginId),error);
				return loginResponse;
			}

			var result = LoginValidator.Validate(request, _userService, out var user);
			if (result.HasError || (user is null)) return (LoginResponse)result;

			_session.LoginUser = user;
			return ResponseFactory.Success<LoginResponse>(nextUrl);
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
