// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Dto.Users;

namespace SessionDomain.Interface
{
	/// <summary>
	/// Session repository
	/// </summary>
	public interface ISessionRepository<TInput>
	{
		/// <summary>
		/// Check if user logged in exists
		/// </summary>
		/// <returns>True if user logged in exists, otherwise, false.</returns>
		bool ExistsLoggedIn();

		/// <summary>
		/// Remove all session information
		/// </summary>
		void RemoveAllSession();

		/// <summary>
		/// Get input
		/// </summary>
		/// <returns>TInput</returns>
		TInput GetInput();

		/// <summary>
		/// Is Exists Input
		/// </summary>
		/// <returns></returns>
		bool IsExistsInput();

		/// <summary>
		/// Set input
		/// </summary>
		/// <param name="input">TInput</param>
		void SetInput(TInput input);

		/// <summary>
		/// Clear input
		/// </summary>
		void Clear();

		/// <summary>Login user</summary>
		LoginUser LoginUser { get; set; }
	}
}
