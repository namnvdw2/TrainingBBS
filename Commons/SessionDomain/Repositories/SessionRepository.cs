// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Dto.Users;
using SessionDomain.Interface;
using System.Web;

namespace SessionDomain.Repositories
{
	/// <summary>
	/// Session repository
	/// </summary>
	public abstract class SessionRepository<TInput> : SessionRepositoryBase, ISessionRepository<TInput>
	{
		/// <summary>Session key login user</summary>
		public const string SESSION_KEY_LOGIN_USER = "login_user";

		/// <summary>
		/// Constructor
		/// </summary>
		public SessionRepository()
			: base()
		{
		}
		/// <summary>
		/// Constructor
		/// </summary>
		public SessionRepository(HttpSessionStateBase session)
			: base(session)
		{
		}

		/// <inheritdoc />
		public bool ExistsLoggedIn() => this.Session[SESSION_KEY_LOGIN_USER] is LoginUser;

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

		/// <inheritdoc />
		public LoginUser LoginUser
		{
			get
			{
				return (LoginUser)this.Session[SESSION_KEY_LOGIN_USER];
			}
			set
			{
				this.Session[SESSION_KEY_LOGIN_USER] = value;
			}
		}
	}
}
