// (c) 2026 W2 Co.,Ltd.

using System.Web;

namespace SessionDomain
{
	/// <summary>
	/// Session repository base class
	/// </summary>
	public abstract class SessionRepositoryBase
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public SessionRepositoryBase()
		{
			this.Session =
				new HttpSessionStateWrapper(HttpContext.Current.Session);
		}
		/// <summary>
		/// Constructor
		/// </summary>
		public SessionRepositoryBase(HttpSessionStateBase session)
		{
			this.Session = session;
		}

		/// <summary>HTTP Session</summary>
		protected HttpSessionStateBase Session { get; set; }
	}
}
