// (c) 2025 W2 Co.,Ltd.

using SessionDomain.Dto.User;
using SessionDomain.Interface;

namespace SessionDomain.Repositories
{
	/// <summary>
	/// Session repository
	/// </summary>
	public abstract class SessionRepository<TInput> : SessionRepositoryBase, ISessionRepository<TInput>
	{
		public const string SESSION_KEY_LOGIN_USER = "login_user";

		/// <summary>
		/// Constructor
		/// </summary>
		public SessionRepository()
			: base()
		{
		}

		/// <inheritdoc />
		public bool ExistsUser()
			=> this.Session[SESSION_KEY_LOGIN_USER] is LoginUser;

		public void RemoveAllSession()
		{
			Session.Contents.RemoveAll();
		}

		/// <inheritdoc />
		public abstract TInput? GetInput();

		/// <inheritdoc />
		public abstract bool IsExistsInput();

		/// <inheritdoc />
		public abstract void SetInput(TInput input);

		/// <inheritdoc />
		public abstract void Clear();

		/// <summary>Login user</summary>
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
