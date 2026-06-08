// (c) 2025 W2 Co.,Ltd.

using SessionDomain.Dto.User;
using SessionDomain.Interface;
using SessionDomain.Repositories;
using System.Data.SqlClient;
using System.Web.SessionState;
using w2.AccountDomain.Domains.Account;
using w2.AccountDomain.Services.Account;
using w2.Common;
using w2.WebFrontDomain.Configurations;
using w2.WebFrontDomain.Dto.Account;
using w2.WebFrontDomain.Validator;

namespace w2.WebFrontDomain.Services.Account
{
	/// <summary>
	/// Login logout service
	/// </summary>
	public class LoginLogoutService
	{
		private readonly AccountService _accountService;
		private readonly SessionRepository _session;

		/// <summary>
		/// Constructor
		/// </summary>
		public LoginLogoutService(
			AccountService accountService,
			SessionRepository session)
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
			if (_session.ExistsUser()) return LoginResponse.CreateSuccessResponse();
			LoginResponse loginResponse = new LoginResponse();
			var error = UserValidator.CheckLoginId(request.LoginId);
			if (error != string.Empty)
			{
				loginResponse.AddError(nameof(request.LoginId),error);
			}

			using (var connection = new SqlConnection(Constants.STRING_SQL_CONNECTION))
			{
				var account = _accountService.GetByLoginId(new LoginId(request.LoginId));
				error = UserValidator.CheckLogin(account?.CreateDto(), request.Password);
				if (error != string.Empty)
				{

				}
				else
				{
					_session.LoginUser = LoginUser.CreateByUser(account);
				}
			}
			return LoginResponse.CreateSuccessResponse(request?.NextUrl);
		}

		/// <summary>
		/// Logout
		/// </summary>
		/// <returns></returns>
		public string Logout()
		{
			_session.RemoveAllSession();
			return ConstantsPage.LoginPageUrl;
		}
	}
}
