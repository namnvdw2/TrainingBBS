// (c) 2026 W2 Co.,Ltd.

using w2.AccountDomain.Domains.Users;

namespace w2.AccountDomain.RepositoryInterfaces.Users
{
	public interface IUserRepository
	{
		/// <summary>
		/// Get user by id
		/// </summary>
		/// <param name="id">Id</param>
		/// <returns>User model</returns>
		User? Get(Id id);

		/// <summary>
		/// Get user by login id
		/// </summary>
		/// <param name="loginId">Login id</param>
		/// <returns>User model</returns>
		User? Get(LoginId loginId);

		/// <summary>
		/// Insert
		/// </summary>
		/// <param name="user">User model</param>
		void Insert(User user);

		/// <summary>
		/// Update
		/// </summary>
		/// <param name="exUser">Ex user model</param>
		/// <param name="user">User model</param>
		void Update(User exUser,
			User user);

		/// <summary>
		/// Withdrawal
		/// </summary>
		/// <param name="userId">User id</param>
		int Withdrawal(Id userId);
	}
}
