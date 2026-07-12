// (c) 2026 W2 Co.,Ltd.

using w2.AccountDomain.Domains.Account;

namespace SessionDomain.Interface
{
	public interface IAccountRegisterSessionRepository
	{
		/// <summary>
		/// Get input
		/// </summary>
		/// <returns>Account input</returns>
		Account GetInput();

		/// <summary>
		/// IsExistsInput
		/// </summary>
		/// <returns>True if session constain account input data, otherwise return false</returns>
		bool IsExistsInput();

		/// <summary>
		/// SetInput
		/// </summary>
		/// <param name="input">Account</param>
		void SetInput(Account input);

		/// <summary>
		/// Clear data
		/// </summary>
		void Clear();
	}
}
