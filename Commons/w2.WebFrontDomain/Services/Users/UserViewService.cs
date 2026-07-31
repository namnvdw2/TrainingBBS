// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Dto.Users;
using SessionDomain.Interface;
using System;
using System.Data;
using w2.AccountDomain.Services.Users;
using w2.Common.Logger;
using w2.Common.Sql.Transactions;
using w2.ForumDomain.Services.Forums;
using w2.FoundationDomain.Transactions;
using w2.WebFrontDomain.Configurations;
using w2.WebFrontDomain.Dto;
using w2.WebFrontDomain.Dto.Users;
using w2.WebFrontDomain.Interface;
using w2.WebFrontDomain.Validator;
using static w2.WebFrontDomain.Validator.CommonMessages;

namespace w2.WebFrontDomain.Services.Users
{
	/// <summary>
	/// User view service
	/// </summary>
	public sealed class UserViewService
	{
		private readonly UserService _userService;
		private readonly ForumService _forumService;
		private readonly IUserRegisterSessionRepository _session;
		private readonly IUserRegisterValidator _userRegisterValidator;

		/// <summary>
		/// Constructor
		/// </summary>
		public UserViewService(
			UserService userService,
			ForumService forumService,
			IUserRegisterSessionRepository session,
			IUserRegisterValidator userRegisterValidator)
		{
			_userService = userService;
			_forumService = forumService;
			_session = session;
			_userRegisterValidator = userRegisterValidator;
		}

		/// <summary>
		/// Register validate
		/// </summary>
		/// <param name="request">User register request</param>
		/// <returns>User register response</returns>
		public UserRegisterModifyResponse RegisterValidate(UserRegisterModifyRequest request)
		{
			if (_session.ExistsLoggedIn())
				return ResponseFactory.Success<UserRegisterModifyResponse>(ConstantsPage.TopForumPageUrl);

			var userRegisterResponse = _userRegisterValidator.ValidateRegisterData(request, _userService);
			if (userRegisterResponse.HasError)
				return userRegisterResponse;

			_session.SetInput(userRegisterResponse.ResponseObject);
			userRegisterResponse = ResponseFactory.Success<UserRegisterModifyResponse>(ConstantsPage.UserRegisterConfirmPageUrl);

			return userRegisterResponse;
		}

		/// <summary>
		/// Initialize input information
		/// </summary>
		/// <returns>User register context response</returns>
		public UserRegisterModifyResponse GetInputInformation()
		{
			var input = _session.IsExistsInput()
				? _session.GetInput()
				: null;
			var response = ResponseFactory.Success<UserRegisterModifyResponse>();
			response.ResponseObject = input;

			return response;
		}

		/// <summary>
		/// Execute registration
		/// </summary>
		/// <returns>Register response</returns>
		public UserRegisterModifyResponse ExecRegister()
		{
			var input = _session.GetInput();
			if (input is null)
				return ResponseFactory.Error<UserRegisterModifyResponse>(ConstantsPage.UserRegisterInputPageUrl);

			var inserted = _userService.Insert(input);
			if (inserted is null)
			{
				var response = ResponseFactory.Error<UserRegisterModifyResponse>(ConstantsPage.UserRegisterInputPageUrl);
				response.Message = CommonMessages.GetMessage(CommonMessageKey.ErrorRegisterFailed);

				return response;
			}

			var user = _userService.GetByLoginId(inserted.LoginId);
			_session.Clear();

			if (user is null)
				return ResponseFactory.Error<UserRegisterModifyResponse>(ConstantsPage.UserRegisterInputPageUrl);

			_session.LoginUser = LoginUser.CreateByUser(user);

			return ResponseFactory.Success<UserRegisterModifyResponse>(ConstantsPage.UserRegisterCompletePageUrl);
		}

		/// <summary>
		/// Execute withdrawal
		/// </summary>
		/// <returns>Register response</returns>
		public BaseResponse ExecWithdrawal()
		{
			if (!_session.ExistsLoggedIn()) return ResponseFactory.Error();

			var loginUser = _session.LoginUser;

			try
			{
				using var transaction = TransactionScopeFactory.Create();

				_userService.Withdrawal(loginUser.UserId);
				_forumService.Withdrawal(loginUser.UserId);

				transaction.Complete();
			}
			catch (Exception ex)
			{
				FileLogger.WriteError(ex);
				var response = ResponseFactory.Error(ConstantsPage.TopForumPageUrl);
				response.Message = CommonMessages.GetMessage(CommonMessageKey.ErrorCancelFailed);

				return response;
			}

			_session.RemoveAllSession();

			return ResponseFactory.Success(ConstantsPage.UserCancelCompletePageUrl);
		}

		/// <summary>
		/// Get login information
		/// </summary>
		/// <returns>Account register modify response</returns>
		public UserRegisterModifyResponse GetLoginAccountOrInputInformation()
		{
			var response = GetInputInformation();

			if (response.ResponseObject is null && _session.ExistsLoggedIn())
			{
				var loginAccount = _session.LoginUser;
				response.ResponseObject = _userService.GetById(loginAccount.UserId);
			}

			if (response.ResponseObject is null)
				return ResponseFactory.Error<UserRegisterModifyResponse>(ConstantsPage.LoginPageUrl);

			return response;
		}

		/// <summary>
		/// Modify validate
		/// </summary>
		/// <param name="request">User modify request</param>
		/// <returns>User register response</returns>
		public UserRegisterModifyResponse ModifyValidate(UserRegisterModifyRequest request)
		{
			if (!_session.ExistsLoggedIn())
				return ResponseFactory.Error<UserRegisterModifyResponse>(ConstantsPage.LoginPageUrl);

			var userRegisterResponse = _userRegisterValidator.ValidateUserData(request);
			if (userRegisterResponse.HasError) return userRegisterResponse;

			_session.SetInput(userRegisterResponse.ResponseObject);
			userRegisterResponse = ResponseFactory.Success<UserRegisterModifyResponse>(ConstantsPage.UserModifyConfirmPageUrl);

			return userRegisterResponse;
		}

		/// <summary>
		/// Execute modify
		/// </summary>
		/// <returns>Modify response</returns>
		public UserRegisterModifyResponse ExecModify()
		{
			var input = _session.GetInput();
			if (input is null || !_session.ExistsLoggedIn())
				return ResponseFactory.Error<UserRegisterModifyResponse>(ConstantsPage.UserModifyInputPageUrl);

			var loginUser = _session.LoginUser;

			var updated = _userService.Update(loginUser.UserId, input);
			if (updated is null)
			{
				var response = ResponseFactory.Error<UserRegisterModifyResponse>(ConstantsPage.UserModifyInputPageUrl);
				response.Message = CommonMessages.GetMessage(CommonMessageKey.ErrorModifyFailed);

				return response;
			}

			var account = _userService.GetByLoginId(updated.LoginId);
			_session.Clear();

			if (account is null)
				return ResponseFactory.Error<UserRegisterModifyResponse>(ConstantsPage.UserModifyInputPageUrl);

			_session.LoginUser = LoginUser.CreateByUser(account);

			return ResponseFactory.Success<UserRegisterModifyResponse>(ConstantsPage.TopForumPageUrl);
		}
	}
}
