// (c) 2026 W2 Co.,Ltd.

using System;
using w2.AccountDomain.Helper;

namespace w2.AccountDomain.Domains.Users
{
	/// <summary>
	/// Password
	/// </summary>
	[Serializable]
	public sealed record Password
	{
		/// <summary>Raw password</summary>
		public string RawPassword { get; }

		/// <summary>Hash password</summary>
		public string HashPassword { get; }

		private Password(string rawPassword, string hashPassword)
		{
			RawPassword = rawPassword;
			HashPassword = hashPassword;
		}

		/// <summary>
		/// Create from plain text
		/// </summary>
		public static Password FromPlainText(string password)
		{
			return new Password(password, HashUtility.CreateHash(password));
		}

		/// <summary>
		/// Create from hash
		/// </summary>
		public static Password FromHash(string hashPassword)
		{
			return new Password(string.Empty, hashPassword);
		}

		/// <summary>
		/// Verify
		/// </summary>
		public bool Verify(string password)
		{
			return HashUtility.Verify(password, HashPassword);
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return RawPassword;
		}
	}
}
