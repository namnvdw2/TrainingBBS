// (c) 2025 W2 Co.,Ltd.

using System.Text.RegularExpressions;

namespace w2.WebFrontDomain
{
	/// <summary>
	/// Utility class for validation checks
	/// </summary>
	public static class ValidatorUtility
	{
		/// <summary>Precompiled regex to check alphanumeric characters (allows empty string to preserve original behavior)</summary>
		private static readonly Regex s_alphanumericRegex =
			new(@"^[0-9A-Za-z]*$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

		/// <summary>
		/// Checks if the specified string is null, empty, or consists only of white-space characters.
		/// </summary>
		/// <param name="value">The string to check. Can be null.</param>
		/// <returns>True if the string is null, empty, or consists only of white-space characters; otherwise false</returns>
		public static bool CheckRequired(string? value) =>
			string.IsNullOrWhiteSpace(value);

		/// <summary>
		/// Checks if the length of the specified string exceeds the given maximum length
		/// </summary>
		/// <param name="value">The string to check</param>
		/// <param name="maxLength">The maximum length</param>
		/// <returns>
		/// True if the length of <paramref name="value"/> is greater than <paramref name="maxLength"/>.
		/// If <paramref name="value"/> is null, it is treated as having length 0 and this method returns false.
		/// </returns>
		public static bool CheckMaxLength(string? value, int maxLength) =>
			(value?.Length ?? 0) > maxLength;

		/// <summary>
		/// Checks if the length of the specified string is less than the given minimum length
		/// </summary>
		/// <param name="value">The string to check</param>
		/// <param name="minLength">The minimum length</param>
		/// <returns>True if the length of <paramref name="value"/> is less than <paramref name="minLength"/>; otherwise false</returns>
		public static bool CheckMinLength(string? value, int minLength) =>
			(value?.Length ?? 0) < minLength;

		/// <summary>
		/// Checks if the specified string consists only of alphanumeric characters (0-9, A-Z, a-z)
		/// </summary>
		/// <param name="value">The string to check</param>
		/// <returns>True if <paramref name="value"/> consists only of alphanumeric characters; otherwise false</returns>
		public static bool CheckAlphanumeric(string? value)
		{
			if (value is null) return false;

			return s_alphanumericRegex.IsMatch(value);
		}
	}
}
