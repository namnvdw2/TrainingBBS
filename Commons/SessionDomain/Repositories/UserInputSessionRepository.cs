// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Interface;
using w2.AccountDomain.Domains.Users;

namespace SessionDomain.Repositories
{
	/// <summary>
	/// User input session repository
	/// </summary>
	public sealed class UserInputSessionRepository : SessionRepository<User>, IUserRegisterSessionRepository
	{
		/// <summary>Session key for user input</summary>
		private const string SESSION_KEY_USER_INPUT = "user_input";

		/// <summary>
		/// Constructor
		/// </summary>
		public UserInputSessionRepository()
			: base()
		{
		}

		/// <inheritdoc />
		public override User GetInput() => this.Session[SESSION_KEY_USER_INPUT] as User;

		/// <inheritdoc />
		public override bool IsExistsInput() => this.Session[SESSION_KEY_USER_INPUT] is User;

		/// <inheritdoc />
		public override void SetInput(User input) => this.Session[SESSION_KEY_USER_INPUT] = input;

		/// <inheritdoc />
		public override void Clear() => this.Session.Contents.Remove(SESSION_KEY_USER_INPUT);
	}
}
