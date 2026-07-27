// (c) 2026 W2 Co.,Ltd.

using w2.AccountDomain.Services.Users;
using w2.WebFrontDomain.Dto.Users;

namespace w2.WebFrontDomain.Interface
{
	/// <summary>
	/// User register validator interface
	/// </summary>
	public interface IUserRegisterValidator
	{
		/// <summary>
		/// Validate register data
		/// </summary>
		/// <param name="request">Use register request</param>
		/// <param name="userService">Use service</param>
		/// <returns>Use Register response</returns>
		UserRegisterModifyResponse ValidateRegisterData(
			UserRegisterModifyRequest request,
			UserService userService);

		/// <summary>
		/// Validate user data
		/// </summary>
		/// <param name="request">User register modify request</param>
		/// <returns>User register modify response</returns>
		UserRegisterModifyResponse ValidateUserData(UserRegisterModifyRequest request);
	}
}
