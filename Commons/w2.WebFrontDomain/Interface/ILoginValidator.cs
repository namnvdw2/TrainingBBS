// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Dto.Users;
using System.Diagnostics.CodeAnalysis;
using w2.AccountDomain.Services.Users;
using w2.WebFrontDomain.Dto.Users;

namespace w2.WebFrontDomain.Interface
{
	/// <summary>
	/// Login validator interface
	/// </summary>
	public interface ILoginValidator
	{
		/// <summary>
		/// Validate
		/// </summary>
		/// <param name="request">Login request</param>
		/// <param name="userService">User service</param>
		/// <param name="resultUser">Login user</param>
		/// <returns>Login response</returns>
		LoginResponse Validate(
			LoginRequest? request,
			UserService userService,
			[NotNullWhen(returnValue: true)] out LoginUser? resultUser);
	}
}
