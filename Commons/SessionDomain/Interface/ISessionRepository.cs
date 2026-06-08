// (c) 2025 W2 Co.,Ltd.

using SessionDomain.Dto.User;

namespace SessionDomain.Interface
{
	/// <summary>
	/// Session repository
	/// </summary>
	public interface ISessionRepository
	{
		/// <summary>
		/// Check if user information exists
		/// </summary>
		/// <returns>True if user information exists; otherwise, false.</returns>
		bool ExistsUser();

		/// <summary>
		/// Remove all session information
		/// </summary>
		void RemoveAllSession();

		/// <summary>Login user</summary>
		LoginUser LoginUser { get; set; }
	}
}
