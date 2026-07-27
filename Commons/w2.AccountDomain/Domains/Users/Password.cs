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
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="rawPassword">Raw password</param>
		/// <param name="hashPassword">Hash password</param>
		private Password(string rawPassword, string hashPassword)
		{
			RawPassword = rawPassword;
			HashPassword = hashPassword;
		}

		/// <summary>
		/// Create from plain text
		/// </summary>
		/// <param name="password">Plain text password</param>
		/// <returns>Password</returns>
		public static Password FromPlainText(string password)
		{
			return new Password(password, HashUtility.CreateHash(password));
		}

		/// <summary>
		/// Create from hash
		/// </summary>
		/// <param name="hashPassword">Hash password</param>
		/// <returns>Password</returns>
		public static Password FromHash(string hashPassword)
			=> new(string.Empty, hashPassword);

		/// <summary>
		/// Verify
		/// </summary>
		/// <param name="password">Password</param>
		/// <returns>True if password is verified, otherwise return false</returns>
		public bool Verify(string password)
			=> HashUtility.Verify(password, HashPassword);

		/// <inheritdoc />
		public override string ToString()
			=> RawPassword;

		/// <summary>
		/// Has raw value
		/// </summary>
		/// <returns>True if RawPassword has value, otherwise return false</returns>
		public bool HasRawValue()
			=> !string.IsNullOrEmpty(RawPassword);

		/// <summary>Raw password</summary>
		public string RawPassword { get; }
		/// <summary>Hash password</summary>
		public string HashPassword { get; }
	}
}
