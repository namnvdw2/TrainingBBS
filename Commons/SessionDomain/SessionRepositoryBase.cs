// (c) 2025 W2 Co.,Ltd.

using System.Web;
using System.Web.SessionState;

namespace SessionDomain
{
	/// <summary>
	/// Session repository base class
	/// </summary>
	public class SessionRepositoryBase
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public SessionRepositoryBase()
		{
			this.Session =
				new HttpSessionStateWrapper(HttpContext.Current.Session);
		}

		/// <summary>HTTP Session</summary>
		protected HttpSessionStateBase Session { get; set; }
	}
}
