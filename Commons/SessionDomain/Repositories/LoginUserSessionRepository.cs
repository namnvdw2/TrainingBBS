// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Dto.Users;
using SessionDomain.Interface;

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

		/// <inheritdoc />
		public override LoginUser GetInput() => IsExistsInput()
			? this.Session[SESSION_KEY_LOGIN_USER] as LoginUser
			: null;

		/// <inheritdoc />
		public override bool IsExistsInput() => this.Session[SESSION_KEY_LOGIN_USER] is LoginUser;

		/// <inheritdoc />
		public override void SetInput(LoginUser input) => this.Session[SESSION_KEY_LOGIN_USER] = input;

		/// <inheritdoc />
		public override void Clear() => this.Session.Contents.Remove(SESSION_KEY_LOGIN_USER);
	}
}
