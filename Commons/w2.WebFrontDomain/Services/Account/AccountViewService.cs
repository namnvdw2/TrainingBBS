// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Dto.Accounts;
using SessionDomain.Repositories;
using w2.AccountDomain.Services.Account;
using w2.WebFrontDomain.Configurations;
using w2.WebFrontDomain.Dto;
using w2.WebFrontDomain.Dto.Account;
using w2.WebFrontDomain.Validator.Accounts;

namespace w2.WebFrontDomain.Services.Account
{
	/// <summary>
	/// Account view service
	/// </summary>
	public class AccountViewService
	{
		private readonly AccountService _accountService;
		private readonly AccountInputSessionRepository _session;

		/// <summary>
		/// Constructor
		/// </summary>
		public AccountViewService(
			AccountService accountService,
			AccountInputSessionRepository session)
		{
			_accountService = accountService;
			_session = session;
		}

		/// <summary>
		/// Register validate
		/// </summary>
		/// <param name="request">Account register request</param>
		/// <returns>Account register response</returns>
		public AccountRegisterModifyResponse RegisterValidate(AccountRegisterModifyRequest request)
		{
			if (_session.ExistsLoggedIn())
				return ResponseFactory.Success<AccountRegisterModifyResponse>(ConstantsPage.TopForumPageUrl);

			var userRegisteResponse = AccountRegisterValidator.RegisterValidate(request, _accountService);
			if (userRegisteResponse.HasError)
				return (AccountRegisterModifyResponse)userRegisteResponse;

			_session.SetInput(userRegisteResponse.ResponseObject);
			userRegisteResponse = ResponseFactory.Success<AccountRegisterModifyResponse>(ConstantsPage.AccountRegisterConfirmPageUrl);

			return userRegisteResponse;
		}

		/// <summary>
		/// Initialize input information
		/// </summary>
		/// <returns>User register context response</returns>
		public AccountRegisterModifyResponse GetInputInfor()
		{
			var input = _session.IsExistsInput()
				? _session.GetInput()
				: null;
			_session.Clear();
			var response = ResponseFactory.Success<AccountRegisterModifyResponse>();
			response.ResponseObject = input;

			return response;
		}

		/// <summary>
		/// Execute registration
		/// </summary>
		/// <returns>Register response</returns>
		public AccountRegisterModifyResponse ExecRegister()
		{
			var input = _session.GetInput();
			if (input is null)
				return ResponseFactory.Error<AccountRegisterModifyResponse>(ConstantsPage.AccountRegisterInputPageUrl);

			_accountService.Insert(input);
			var account = _accountService.GetByLoginId(input.LoginId);
			_session.Clear();

			if (account is null)
				return ResponseFactory.Error<AccountRegisterModifyResponse>(ConstantsPage.AccountRegisterInputPageUrl);

			_session.LoginAccount = LoginAccount.CreateByUser(account);

			return ResponseFactory.Success<AccountRegisterModifyResponse>(ConstantsPage.AccountRegisterCompletePageUrl);
		}

		/// <summary>
		/// Execute withdrawal
		/// </summary>
		/// <returns>Register response</returns>
		public BaseResponse ExcecWithdrawal()
		{
			if (_session.ExistsLoggedIn())
				return ResponseFactory.Error();

			var loginUser = _session.LoginAccount;
			_accountService.Withdrawal(loginUser.AccountId);
			_session.RemoveAllSession();

			return ResponseFactory.Success(ConstantsPage.AccountCancelCompletePageUrl);
		}

		/// <summary>
		/// Get login information
		/// </summary>
		/// <returns>Account register modify response</returns>
		public AccountRegisterModifyResponse GetLoginAccountOrInputInfor()
		{
			var response = GetInputInfor();

			if (response.ResponseObject is null && _session.ExistsLoggedIn())
			{
				var loginAccount = _session.LoginAccount;
				response.ResponseObject = _accountService.GetById(loginAccount.AccountId);
			}

			if (response.ResponseObject is null)
				return ResponseFactory.Error<AccountRegisterModifyResponse>(ConstantsPage.LoginPageUrl);

			return response;
		}

		/// <summary>
		/// Modify validate
		/// </summary>
		/// <param name="request">Account modify request</param>
		/// <returns>Account register response</returns>
		public AccountRegisterModifyResponse ModifyValidate(AccountRegisterModifyRequest request)
		{
			if (!_session.ExistsLoggedIn())
				return ResponseFactory.Error<AccountRegisterModifyResponse>(ConstantsPage.LoginPageUrl);

			var userRegisteResponse = AccountRegisterValidator.DataValidate(request);
			if (userRegisteResponse.HasError) return userRegisteResponse;

			_session.SetInput(userRegisteResponse.ResponseObject);
			userRegisteResponse = ResponseFactory.Success<AccountRegisterModifyResponse>(ConstantsPage.AccountModifyConfirmPageUrl);

			return userRegisteResponse;
		}
	}
}
