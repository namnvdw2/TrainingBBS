// (c) 2026 W2 Co.,Ltd.

using w2.AccountDomain.Domains.Users;

namespace SessionDomain.Interface
{
	/// <summary>
	/// User register session repository interface
	/// </summary>
	public interface IUserRegisterSessionRepository :  ISessionRepository<User>
	{
	}
}
