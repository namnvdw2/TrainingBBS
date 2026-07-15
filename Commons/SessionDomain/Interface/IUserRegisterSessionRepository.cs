// (c) 2026 W2 Co.,Ltd.

using w2.AccountDomain.Domains.Users;

namespace SessionDomain.Interface
{
	public interface IUserRegisterSessionRepository
	{
		/// <summary>
		/// Get input
		/// </summary>
		/// <returns>User input</returns>
		User GetInput();

		/// <summary>
		/// IsExistsInput
		/// </summary>
		/// <returns>True if session constain user input data, otherwise return false</returns>
		bool IsExistsInput();

		/// <summary>
		/// SetInput
		/// </summary>
		/// <param name="input">User</param>
		void SetInput(User input);

		/// <summary>
		/// Clear data
		/// </summary>
		void Clear();
	}
}
