// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Dto.Users;
using SessionDomain.Interface;
using System.Web;

namespace SessionDomain.Repositories
{
	/// <summary>
	/// Login user session repository
	/// </summary>
	public sealed class LoginUserSessionRepository : SessionRepository<LoginUser>, ILoginUserSessionRepository
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public LoginUserSessionRepository()
			: base()
		{
		}
		/// <summary>
		/// Constructor
		/// </summary>
		public LoginUserSessionRepository(HttpSessionStateBase session)
			: base(session)
		{
		}

		/// <inheritdoc />
		public override LoginUser GetInput() => this.Session[SESSION_KEY_LOGIN_USER] as LoginUser;

		/// <inheritdoc />
		public override bool IsExistsInput() => this.Session[SESSION_KEY_LOGIN_USER] is LoginUser;

		/// <inheritdoc />
		public override void SetInput(LoginUser input) => this.Session[SESSION_KEY_LOGIN_USER] = input;

		/// <inheritdoc />
		public override void Clear() => this.Session.Contents.Remove(SESSION_KEY_LOGIN_USER);
	}
}
