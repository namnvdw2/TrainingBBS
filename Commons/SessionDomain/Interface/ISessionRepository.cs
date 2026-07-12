// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Dto.Accounts;

namespace SessionDomain.Interface
{
	/// <summary>
	/// Session repository
	/// </summary>
	public interface ISessionRepository<TInput>
	{
		/// <summary>
		/// Check if account logged in exists
		/// </summary>
		/// <returns>True if  account logged in exists, otherwise, false.</returns>
		bool ExistsLoggedIn();

		/// <summary>
		/// Remove all session information
		/// </summary>
		void RemoveAllSession();

		/// <summary>
		/// Get input
		/// </summary>
		/// <returns>TInput</returns>
		public TInput GetInput();

		/// <summary>
		/// Is Exists Input
		/// </summary>
		/// <returns></returns>
		public bool IsExistsInput();

		/// <summary>
		/// Set input
		/// </summary>
		/// <param name="input">TInput</param>
		public void SetInput(TInput input);

		/// <summary>
		/// Clear input
		/// </summary>
		public void Clear();

		/// <summary>Login account</summary>
		LoginAccount LoginAccount { get; set; }
	}
}
