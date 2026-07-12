// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Dto.Accounts;
using SessionDomain.Interface;

namespace SessionDomain.Repositories
{
	/// <summary>
	/// Session repository
	/// </summary>
	public abstract class SessionRepository<TInput> : SessionRepositoryBase, ISessionRepository<TInput>
	{
		/// <summary>Session key login account</summary>
		public const string SESSION_KEY_LOGIN_ACCOUNT = "login_account";

		/// <summary>
		/// Constructor
		/// </summary>
		public SessionRepository()
			: base()
		{
		}

		/// <inheritdoc />
		public bool ExistsLoggedIn() => this.Session[SESSION_KEY_LOGIN_ACCOUNT] is LoginAccount;

		/// <inheritdoc />
		public void RemoveAllSession() => Session.Contents.RemoveAll();

		/// <inheritdoc />
		public abstract TInput GetInput();

		/// <inheritdoc />
		public abstract bool IsExistsInput();

		/// <inheritdoc />
		public abstract void SetInput(TInput input);

		/// <inheritdoc />
		public abstract void Clear();

		/// <summary>Login account</summary>
		public LoginAccount LoginAccount
		{
			get
			{
				return (LoginAccount)this.Session[SESSION_KEY_LOGIN_ACCOUNT];
			}
			set
			{
				this.Session[SESSION_KEY_LOGIN_ACCOUNT] = value;
			}
		}
	}
}
