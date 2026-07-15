// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Dto.Users;

namespace SessionDomain.Interface
{
	public interface ILoginUserSessionRepository
	{
		/// <summary>
		/// Get input
		/// </summary>
		/// <returns>Login user input</returns>
		LoginUser GetInput();

		/// <summary>
		/// Is exists input
		/// </summary>
		/// <returns>True if session constain login user data, otherwise return false</returns>
		bool IsExistsInput();

		/// <summary>
		/// SetInput
		/// </summary>
		/// <param name="input">Login user</param>
		void SetInput(LoginUser input);

		/// <summary>
		/// Clear data
		/// </summary>
		void Clear();
	}
}
