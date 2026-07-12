// (c) 2026 W2 Co.,Ltd.

namespace SessionDomain.Interface
{
	/// <summary>
	/// Interface for session error repository
	/// </summary>
	public interface ISessionErrorRepository
	{
		/// <summary>
		/// Get error message
		/// </summary>
		/// <returns>Error message</returns>
		string GetError();

		/// <summary>
		/// Set error message
		/// </summary>
		/// <param name="errorMessage">The error message</param>
		void SetError(string errorMessage);

		/// <summary>
		/// Clear error message
		/// </summary>
		void ClearError();
	}
}
