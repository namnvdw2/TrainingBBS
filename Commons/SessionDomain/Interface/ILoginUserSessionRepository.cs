// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Dto.Users;

namespace SessionDomain.Interface
{
	/// <summary>
	/// Login user session repository interface
	/// </summary>
	public interface ILoginUserSessionRepository : ISessionRepository<LoginUser>
	{
	}
}
