// (c) 2025 W2 Co.,Ltd.

using SessionDomain.Interface;
using w2.AccountDomain.Domains.Account;

namespace SessionDomain.Repositories
{
	/// <summary>
	/// User register session repository
	/// </summary>
	public class UserRegisterSessionRepository : SessionRepository<AccountModel>, IUserRegisterSessionRepository
	{
		/// <summary>Session key for user registration input</summary>
		private const string SESSION_KEY_USER_REGISTER = "user_register_input";

		/// <summary>
		/// Constructor
		/// </summary>
		public UserRegisterSessionRepository()
			: base()
		{
		}

		/// <inheritdoc />
		public override AccountModel? GetInput() => IsExistsInput()
			? this.Session[SESSION_KEY_USER_REGISTER] as AccountModel
			: null;

		/// <inheritdoc />
		public override bool IsExistsInput() => this.Session[SESSION_KEY_USER_REGISTER] is AccountModel;

		/// <inheritdoc />
		public override void SetInput(AccountModel input) => this.Session[SESSION_KEY_USER_REGISTER] = input;

		/// <inheritdoc />
		public override void Clear() => this.Session.Contents.Remove(SESSION_KEY_USER_REGISTER);
	}
}
