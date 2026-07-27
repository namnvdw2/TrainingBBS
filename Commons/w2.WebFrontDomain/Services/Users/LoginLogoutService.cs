// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Interface;
using w2.AccountDomain.Services.Users;
using w2.WebFrontDomain.Configurations;
using w2.WebFrontDomain.Dto;
using w2.WebFrontDomain.Dto.Users;
using w2.WebFrontDomain.Interface;
using w2.WebFrontDomain.Validator.Users;
using w2.WebFrontDomain.ViewModels;

namespace w2.WebFrontDomain.Services.Users
{
	/// <summary>
	/// Login logout service
	/// </summary>
	public sealed class LoginLogoutService
	{
		private readonly UserService _userService;
		private readonly ILoginUserSessionRepository _session;
		private readonly ILoginValidator _loginValidator;

		/// <summary>
		/// Constructor
		/// </summary>
		public LoginLogoutService(
			UserService userService,
			ILoginUserSessionRepository session,
			ILoginValidator loginValidator)
		{
			_userService = userService;
			_session = session;
			_loginValidator = loginValidator;
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

			var result = _loginValidator.Validate(request, _userService, out var user);
			if (result.HasError || (user is null)) return (LoginResponse)result;

			_session.LoginUser = user;
			return ResponseFactory.Success<LoginResponse>(nextUrl);
		}

		/// <summary>
		/// Logout
		/// </summary>
		/// <returns>Base response</returns>
		public BaseResponse Logout()
		{
			_session.RemoveAllSession();
			return new BaseResponse()
			{
				RedirectUrl = ConstantsPage.LoginPageUrl
			};
		}

		/// <summary>
		/// Set login user to view model
		/// </summary>
		public void SetLoginUserToViewModel(object oldViewModel)
		{
			if (_session is not null && _session.ExistsLoggedIn())
			{
				if (oldViewModel is BaseViewModel vm)
				{
					var loginUser = _session.LoginUser;

					vm.IsLogin = loginUser != null;
					vm.LoginUserName = loginUser?.Name.AsString;
				}
			}
		}
	}
}
