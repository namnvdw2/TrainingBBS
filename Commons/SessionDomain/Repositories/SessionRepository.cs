// (c) 2025 W2 Co.,Ltd.

using SessionDomain.Dto.User;
using SessionDomain.Interface;
using System.Web;

namespace SessionDomain.Repositories
{
	/// <summary>
	/// Session repository
	/// </summary>
	public class SessionRepository : SessionRepositoryBase, ISessionRepository
	{
		private const string SESSION_KEY_LOGIN_USER = "login_user";

		public SessionRepository()
			: base()
		{
		}

		public bool ExistsUser()
			=> this.Session[SESSION_KEY_LOGIN_USER] is LoginUser;

		public void RemoveAllSession()
		{
			Session.Contents.RemoveAll();
		}

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
