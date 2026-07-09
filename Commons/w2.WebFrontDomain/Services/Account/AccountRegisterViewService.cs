// (c) 2025 W2 Co.,Ltd.

using SessionDomain.Dto.User;
using SessionDomain.Repositories;
using System.Data.SqlClient;
using w2.AccountDomain.Services.Account;
using w2.Common;
using w2.WebFrontDomain.Configurations;
using w2.WebFrontDomain.Dto.Account;
using w2.WebFrontDomain.Validator.User;

namespace w2.WebFrontDomain.Services.Account
{
	/// <summary>
	/// Account register view service
	/// </summary>
	public class AccountRegisterViewService
	{
		private readonly AccountService _accountService;
		private readonly UserRegisterSessionRepository _session;

		/// <summary>
		/// Constructor
		/// </summary>
		public AccountRegisterViewService(
			AccountService accountService,
			UserRegisterSessionRepository session)
		{
			_accountService = accountService;
			_session = session;
		}

		/// <summary>
		/// Validate
		/// </summary>
		/// <param name="request">User register request</param>
		/// <returns>User register response</returns>
		public UserRegisterResponse Validate(UserRegisterRequest request)
		{
			if (_session.ExistsUser()) return UserRegisterResponse.CreateSuccessResponse();

			UserRegisterResponse userRegisteResponse = new UserRegisterResponse();
			using (var connection = new SqlConnection(Constants.STRING_SQL_CONNECTION))
			{
				userRegisteResponse = UserRegisterValidator.Validate(request, _accountService);
				if (userRegisteResponse.HasError) return (UserRegisterResponse)userRegisteResponse;
			}
			_session.SetInput(userRegisteResponse.ResponseObject);
			userRegisteResponse = UserRegisterResponse.CreateSuccessResponse(ConstantsPage.UserRegisterConfirmPageUrl);

			return userRegisteResponse;
		}

		/// <summary>
		/// Initialize input
		/// </summary>
		/// <returns>User register context response</returns>
		public UserRegisterResponse InputInit()
		{
			var input = _session.IsExistsInput()
				? _session.GetInput()
				: null;
			var response = UserRegisterResponse.CreateSuccessResponse();
			response.ResponseObject = input;

			return response;
		}

		/// <summary>
		/// Execute registration
		/// </summary>
		/// <returns>Register response</returns>
		public UserRegisterResponse ExecRegister()
		{
			var input = _session.GetInput();
			if (input is null)
				return UserRegisterResponse.CreateErrorResponse(ConstantsPage.UserRegisterInputPageUrl);

			_accountService.Insert(input);
			var account = _accountService.GetByLoginId(input.LoginId);
			_session.Clear();

			if (account is null)
				return UserRegisterResponse.CreateErrorResponse(ConstantsPage.UserRegisterInputPageUrl);

			_session.LoginUser = LoginUser.CreateByUser(account);

			return UserRegisterResponse.CreateSuccessResponse(ConstantsPage.UserRegisterCompletePageUrl);
		}
	}
}
