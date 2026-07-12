// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Dto.Accounts;

namespace SessionDomain.Interface
{
	public interface ILoginAccountSessionRepository
	{
		/// <summary>
		/// Get input
		/// </summary>
		/// <returns>Login account input</returns>
		LoginAccount GetInput();

		/// <summary>
		/// IsExistsInput
		/// </summary>
		/// <returns>True if session constain login account data, otherwise return false</returns>
		bool IsExistsInput();

		/// <summary>
		/// SetInput
		/// </summary>
		/// <param name="input">Login account</param>
		void SetInput(LoginAccount input);

		/// <summary>
		/// Clear data
		/// </summary>
		void Clear();
	}
}
