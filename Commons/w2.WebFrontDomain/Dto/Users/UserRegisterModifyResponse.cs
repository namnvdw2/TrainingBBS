// (c) 2026 W2 Co.,Ltd.

using System;
using w2.WebFrontDomain.ViewModels.Users;

namespace w2.WebFrontDomain.Dto.Users
{
	/// <summary>
	/// User register modify response
	/// </summary>
	[Serializable]
	public sealed class UserRegisterModifyResponse : BaseResponse<AccountDomain.Domains.Users.User>
	{
		/// <summary>
		/// To view model
		/// </summary>
		/// <param name="backUrl">Back url</param>
		/// <param name="includePassword">Include password</param>
		/// <returns>User register modify view model</returns>
		public UserRegisterModifyViewModel ToViewModel(string backUrl, bool includePassword = false)
		{
			var viewModel = new UserRegisterModifyViewModel
			{
				BackUrl = backUrl,
			};

			if (ResponseObject is not null)
			{
				viewModel.LoginId = ResponseObject.LoginId.AsString;
				viewModel.Name = ResponseObject.Name.AsString;
				viewModel.Password = includePassword ? ResponseObject.Password.ToString() : null;
			}

			return viewModel;
		}
	}
}
