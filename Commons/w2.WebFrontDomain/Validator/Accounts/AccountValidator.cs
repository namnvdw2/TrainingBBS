// (c) 2026 W2 Co.,Ltd.

using static w2.WebFrontDomain.Validator.CommonMessages;

namespace w2.WebFrontDomain.Validator.Accounts
{
	/// <summary>
	/// Account validator
	/// </summary>
	public class AccountValidator
	{
		/// <summary>Maximum length for login ID</summary>
		protected const int MAX_LENGTH_LOGIN_ID = 15;
		/// <summary>Maximum length for password</summary>
		protected const int MAX_LENGTH_PASSWORD = 15;
		/// <summary>Minimum length for password</summary>
		protected const int MIN_LENGTH_PASSWORD = 6;
		/// <summary>Minimum length for login ID</summary>
		protected const int MIN_LENGTH_LOGIN_ID = 3;
		/// <summary>Maximum length for user name</summary>
		protected const int MAX_LENGTH_USER_NAME = 50;
		/// <summary>Error key for login ID</summary>
		protected const string LOGIN_ID_ERROR_KEY = "loginId";
		/// <summary>Error key for password</summary>
		protected const string PASSWORD_ERROR_KEY = "password";
		/// <summary>Error key for name</summary>
		protected const string USER_NAME_ERROR_KEY = "name";
		/// <summary>Login ID field name</summary>
		internal const string LOGIN_ID_FIELD_NAME = "ログインID";
		/// <summary>Password field name</summary>
		internal const string PASSWORD_FIELD_NAME = "パスワード";
		/// <summary>User name field name</summary>
		internal const string USER_NAME_FIELD_NAME = "ユーザー名";

		/// <summary>
		/// Check login id
		/// </summary>
		/// <param name="loginId">Login id</param>
		/// <returns>Error message</returns>
		public static string CheckLoginId(string? loginId)
		{
			if (ValidatorUtility.CheckRequired(loginId))
			{
				return GetMessage(CommonMessageKey.FormatErrorRequired, LOGIN_ID_FIELD_NAME);
			}

			if (ValidatorUtility.CheckMinLength(loginId, MIN_LENGTH_LOGIN_ID))
			{
				return GetMessage(
					CommonMessageKey.FormatErrorMinLength,
					LOGIN_ID_FIELD_NAME,
					MIN_LENGTH_LOGIN_ID.ToString());
			}

			if (ValidatorUtility.CheckMaxLength(loginId, MAX_LENGTH_LOGIN_ID))
			{
				return GetMessage(
					CommonMessageKey.FormatErrorMaxLength,
					LOGIN_ID_FIELD_NAME,
					MAX_LENGTH_LOGIN_ID.ToString());
			}

			if (!ValidatorUtility.CheckAlphanumeric(loginId))
			{
				return GetMessage(CommonMessageKey.FormatErrorAlphanumeric, LOGIN_ID_FIELD_NAME);
			}

			return string.Empty;
		}

		/// <summary>
		/// Check password
		/// </summary>
		/// <param name="password">The password</param>
		/// <returns>Error message if validation fails, otherwise an empty string</returns>
		public static string CheckPassword(string? password)
		{
			if (ValidatorUtility.CheckRequired(password))
			{
				return GetMessage(CommonMessageKey.FormatErrorRequired, PASSWORD_FIELD_NAME);
			}

			if (ValidatorUtility.CheckMinLength(password, MIN_LENGTH_PASSWORD))
			{
				return GetMessage(
					CommonMessageKey.FormatErrorMinLength,
					PASSWORD_FIELD_NAME,
					MIN_LENGTH_PASSWORD.ToString());
			}

			if (ValidatorUtility.CheckMaxLength(password, MAX_LENGTH_PASSWORD))
			{
				return GetMessage(
					CommonMessageKey.FormatErrorMaxLength,
					PASSWORD_FIELD_NAME,
					MAX_LENGTH_PASSWORD.ToString());
			}

			if (!ValidatorUtility.CheckAlphanumeric(password))
			{
				return GetMessage(CommonMessageKey.FormatErrorAlphanumeric, PASSWORD_FIELD_NAME);
			}

			return string.Empty;
		}

		/// <summary>
		/// Check name
		/// </summary>
		/// <param name="name">The name</param>
		/// <returns>Error message if validation fails, otherwise return empty string</returns>
		public static string CheckName(string? name)
		{
			if (ValidatorUtility.CheckRequired(name))
			{
				return GetMessage(CommonMessageKey.FormatErrorRequired, USER_NAME_FIELD_NAME);
			}

			if (ValidatorUtility.CheckMaxLength(name, MAX_LENGTH_USER_NAME))
			{
				return GetMessage(
					CommonMessageKey.FormatErrorMaxLength,
					USER_NAME_FIELD_NAME,
					MAX_LENGTH_USER_NAME.ToString());
			}

			return string.Empty;
		}
	}
}
