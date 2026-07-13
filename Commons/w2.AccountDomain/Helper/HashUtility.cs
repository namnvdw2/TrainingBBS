// (c) 2026 W2 Co.,Ltd.

using System.Security.Cryptography;
using System.Text;

namespace w2.AccountDomain.Helper
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
		/// <returns>Hashed value</returns>
		public static string CreateHash(string value)
		{
			if (string.IsNullOrEmpty(value)) return string.Empty;

			using (var sha256 = SHA256.Create())
			{
				var bytes = Encoding.UTF8.GetBytes(value);
				var hash = sha256.ComputeHash(bytes);

				var builder = new StringBuilder(hash.Length * 2);
				foreach (var b in hash)
				{
					builder.Append(b.ToString("x2"));
				}

				return builder.ToString();
			}
		}

		/// <summary>
		/// Verify
		/// </summary>
		/// <param name="plainText">Plain text</param>
		/// <param name="hash">Hash</param>
		/// <returns>True if verify OK, otherwise return false</returns>
		public static bool Verify(string plainText, string hash)
		{
			return CreateHash(plainText) == hash;
		}
	}
}
