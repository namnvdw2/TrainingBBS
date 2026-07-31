// (c) 2026 W2 Co.,Ltd.

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace w2.AccountDomain.Domains.Users
{
	/// <summary>
	/// Password
	/// </summary>
	[Serializable]
	public sealed record Password
	{
		/// <summary>Password display text</summary>
		public const string MASKED_TEXT = "********";

		/// <summary>Password encoding</summary>
		private static readonly Encoding s_encoding = Encoding.UTF8;
		/// <summary>Random number generator</summary>
		private static readonly Random s_random = new();

		/// <summary>Hash</summary>
		private readonly byte[] _hash;
		/// <summary>Salt</summary>
		private readonly byte[] _salt;
		/// <summary>Validation flag (when false, password validation always fails)</summary>
		private readonly bool _isValidatable;

		/// <summary>
		/// Password
		/// </summary>
		/// <param name="hash">Hash</param>
		/// <param name="salt">salt</param>
		/// <param name="isValidatable">Is validatable</param>
		private Password(byte[] hash, byte[] salt, bool isValidatable)
		{
			_hash = hash;
			_salt = salt;
			_isValidatable = isValidatable;
		}

		/// <summary>
		/// Create from base 64 encoded
		/// </summary>
		/// <param name="hashedPassword">Hashed password</param>
		/// <returns>Password</returns>
		public static Password CreateFromBase64Encoded(string hashedPassword)
		{
			byte[] bytes;
			try
			{
				bytes = Convert.FromBase64String(hashedPassword);
			}
			catch (FormatException)
			{
				return new Password(
					Array.Empty<byte>(),
					Array.Empty<byte>(),
					isValidatable: false);
			}

			if (bytes.Length != 64)
			{
				return new Password(
					Array.Empty<byte>(),
					Array.Empty<byte>(),
					isValidatable: false);
			}

			return new Password(
				bytes.Take(32).ToArray(),
				bytes.Skip(32).Take(32).ToArray(),
				isValidatable: true);
		}

		/// <summary>
		/// Create new
		/// </summary>
		/// <param name="password">Raw password</param>
		/// <returns>Password</returns>
		public static Password CreateNew(string password)
		{
			byte[] salt;
			lock (s_random)
			{
				salt = Enumerable.Repeat(0, 32).Select(_ => Convert.ToByte(s_random.Next(256))).ToArray();
			}
			var bytePassword = s_encoding.GetBytes(password);
			using var sha = SHA256.Create();
			var hash = sha.ComputeHash(bytePassword.Concat(salt).ToArray());

			return new Password(hash, salt, isValidatable: true);
		}

		/// <summary>
		/// Validate
		/// </summary>
		/// <param name="password">Raw password</param>
		/// <returns>True if validated, otherwise return false</returns>
		public bool Validate(string password)
		{
			if (!_isValidatable) return false;

			using var sha = SHA256.Create();

			var bytePassword = s_encoding.GetBytes(password);
			var actually = sha.ComputeHash(bytePassword.Concat(_salt).ToArray());

			return actually.SequenceEqual(_hash);
		}

		/// <summary>
		/// Encode
		/// </summary>
		/// <returns>Encode password</returns>
		public string Encode()
		{
			if (!_isValidatable) return string.Empty;

			var result = Convert.ToBase64String(_hash.Concat(_salt).ToArray());

			return result;
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return MASKED_TEXT;
		}
	}
}
