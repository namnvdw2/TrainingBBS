// (c) 2025 W2 Co.,Ltd.

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
		/// <summary>Account service</summary>
		private readonly AccountService _accountService;
		/// <summary>User register session repository</summary>
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
			if (_session.ExistsUser()) return UserRegisterResponse.CreateSuccessResponse(request?.NextUrl);

			UserRegisterResponse userRegisteResponse = UserRegisterResponse.CreateSuccessResponse(ConstantsPage.UserRegisterConfirmPageUrl);
			using (var connection = new SqlConnection(Constants.STRING_SQL_CONNECTION))
			{
				userRegisteResponse = UserRegisterValidater.Validate(request, _accountService);
				if (userRegisteResponse.HasError) return (UserRegisterResponse)userRegisteResponse;
			}
			_session.SetInput(userRegisteResponse.ResponseObject);

			return userRegisteResponse;
		}
	}
}
