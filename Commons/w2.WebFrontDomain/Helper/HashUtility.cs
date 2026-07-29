// (c) 2026 W2 Co.,Ltd.

using System.Security.Cryptography;
using System.Text;

namespace w2.WebFrontDomain.Helper
{
	/// <summary>
	/// Hash utility
	/// </summary>
	public static class HashUtility
	{
		/// <summary>
		/// Create hash
		/// </summary>
		/// <param name="value">Text value</param>
		/// <param name="salt">Salt value</param>
		/// <returns>Hashed value</returns>
		public static string CreateHash(string value, string salt)
		{
			if (string.IsNullOrEmpty(value)) return string.Empty;

			using var sha256 = SHA256.Create();
			var bytes = Encoding.UTF8.GetBytes(value + salt);
			var hash = sha256.ComputeHash(bytes);

			var builder = new StringBuilder(hash.Length * 2);
			foreach (var saltByte in hash)
			{
				builder.Append(saltByte.ToString("x2"));
			}

			return builder.ToString();
		}

		/// <summary>
		/// Create salt
		/// </summary>
		/// <returns>Random salt value</returns>
		public static string CreateSalt()
		{
			var saltBytes = new byte[16];

			using (var randomNumber = RandomNumberGenerator.Create())
			{
				randomNumber.GetBytes(saltBytes);
			}

			var builder = new StringBuilder(saltBytes.Length * 2);
			foreach (var saltByte in saltBytes)
			{
				builder.Append(saltByte.ToString("x2"));
			}

			return builder.ToString();
		}

		/// <summary>
		/// Verify
		/// </summary>
		/// <param name="plainText">Plain text</param>
		/// <param name="hash">Hash</param>
		/// <param name="salt">Salt</param>
		/// <returns>True if verify OK, otherwise return false</returns>
		public static bool Verify(string plainText, string hash, string salt)
		{
			return CreateHash(plainText, salt) == hash;
		}
	}
}
