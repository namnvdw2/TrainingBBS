// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Interface;

namespace SessionDomain.Repositories
{
	/// <summary>
	/// Session repository for error messages
	/// </summary>
	public sealed class SessionErrorRepository : SessionRepositoryBase, ISessionErrorRepository
	{
		/// <summary>Session key for error message</summary>
		private const string SESSION_KEY_ERROR_MESSAGE = "error_message";

		/// <summary>
		/// Constructor
		/// </summary>
		public SessionErrorRepository()
		{
		}

		/// <inheritdoc />
		public string GetError()
		{
			if (this.Session[SESSION_KEY_ERROR_MESSAGE] is null)
			{
				return null;
			}

			return (string)this.Session[SESSION_KEY_ERROR_MESSAGE];
		}

		/// <inheritdoc />
		public void SetError(string errorMessage)
		{
			this.Session[SESSION_KEY_ERROR_MESSAGE] = errorMessage;
		}

		/// <inheritdoc />
		public void ClearError()
		{
			this.Session[SESSION_KEY_ERROR_MESSAGE] = null;
		}
	}
}
