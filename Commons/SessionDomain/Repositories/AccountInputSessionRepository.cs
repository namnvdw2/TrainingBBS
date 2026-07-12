// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Interface;
using w2.AccountDomain.Domains.Account;

namespace SessionDomain.Repositories
{
	/// <summary>
	/// Account input session repository
	/// </summary>
	public class AccountInputSessionRepository : SessionRepository<Account>, IAccountRegisterSessionRepository
	{
		/// <summary>Session key for account input</summary>
		private const string SESSION_KEY_ACCOUNT_INPUT = "account_input";

		/// <summary>
		/// Constructor
		/// </summary>
		public AccountInputSessionRepository()
			: base()
		{
		}

		/// <inheritdoc />
		public override Account GetInput() => IsExistsInput()
			? this.Session[SESSION_KEY_ACCOUNT_INPUT] as Account
			: null;

		/// <inheritdoc />
		public override bool IsExistsInput() => this.Session[SESSION_KEY_ACCOUNT_INPUT] is Account;

		/// <inheritdoc />
		public override void SetInput(Account input) => this.Session[SESSION_KEY_ACCOUNT_INPUT] = input;

		/// <inheritdoc />
		public override void Clear() => this.Session.Contents.Remove(SESSION_KEY_ACCOUNT_INPUT);
	}
}
