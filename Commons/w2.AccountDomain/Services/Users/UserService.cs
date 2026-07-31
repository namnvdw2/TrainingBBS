// (c) 2026 W2 Co.,Ltd.

using w2.AccountDomain.Domains.Users;
using w2.AccountDomain.RepositoryInterfaces.Users;

namespace w2.AccountDomain.Services.Users
{
	/// <summary>
	/// User service
	/// </summary>
	public sealed class UserService
	{
		private readonly IUserRepository _userRepository;

		/// <summary>
		/// Constructor
		/// </summary>
		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		/// <summary>
		/// Get by id
		/// </summary>
		/// <param name="id">User id</param>
		/// <returns>User</returns>
		public User? GetById(UserId id)
		{
			var user = _userRepository.Get(id);
			return user;
		}

		/// <summary>
		/// Get by login id
		/// </summary>
		/// <param name="loginId">Login id</param>
		/// <returns>Account</returns>
		public User? GetByLoginId(LoginId loginId)
		{
			var user = _userRepository.Get(loginId);
			return user;
		}

		/// <summary>
		/// Insert user
		/// </summary>
		/// <param name="user">User</param>
		/// <returns>User inserted</returns>
		public User? Insert(User user)
		{
			var existed = _userRepository.Get(user.LoginId);
			if (existed is null)
			{
				_userRepository.Insert(user);

				return user;
			}

			return null;
		}

		/// <summary>
		/// Update account
		/// </summary>
		/// <param name="id">User id</param>
		/// <param name="user">User</param>
		/// <returns>User updated</returns>
		public User? Update(UserId id, User user)
		{
			var existed = _userRepository.Get(id);
			if (existed is not null)
			{
				_userRepository.Update(existed, user);

				return user;
			}

			return null;
		}

		/// <summary>
		/// Withdrawal
		/// </summary>
		/// <param name="userId">User id</param>
		/// <returns>Withdrawaled</returns>
		public int Withdrawal(UserId userId)
		{
			var existed = _userRepository.Get(userId);
			if (existed is null) return 0;

			return _userRepository.Withdrawal(userId);
		}
	}
}
