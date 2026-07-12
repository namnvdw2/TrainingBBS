// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Dto.Accounts;
using SessionDomain.Interface;

namespace SessionDomain.Repositories
{
	/// <summary>
	/// Login account session repository
	/// </summary>
	public class LoginAccountSessionRepository : SessionRepository<LoginAccount>, ILoginAccountSessionRepository
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public LoginAccountSessionRepository()
			: base()
		{
		}

		/// <inheritdoc />
		public override LoginAccount GetInput() => IsExistsInput()
			? this.Session[SESSION_KEY_LOGIN_ACCOUNT] as LoginAccount
			: null;

		/// <inheritdoc />
		public override bool IsExistsInput() => this.Session[SESSION_KEY_LOGIN_ACCOUNT] is LoginAccount;

		/// <inheritdoc />
		public override void SetInput(LoginAccount input) => this.Session[SESSION_KEY_LOGIN_ACCOUNT] = input;

		/// <inheritdoc />
		public override void Clear() => this.Session.Contents.Remove(SESSION_KEY_LOGIN_ACCOUNT);
	}
}
