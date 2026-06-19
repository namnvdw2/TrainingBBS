// (c) 2025 W2 Co.,Ltd.

using w2.AccountDomain.Dto.Account;
using static w2.WebFrontDomain.Validator.CommonMessages;

namespace w2.WebFrontDomain.Validator.User
{
	/// <summary>
	/// User validator
	/// </summary>
	public class UserValidator
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
		public static string CheckLoginId(string loginId)
		{
			if (ValidatorUtility.CheckRequired(loginId))
			{
				return GetMessage(CommonMessageKey.ErrorLoggedInRequired, LOGIN_ID_FIELD_NAME);
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

			if (ValidatorUtility.CheckAlphanumeric(loginId) == false)
			{
				return GetMessage(CommonMessageKey.ErrorLoggedInRequired, LOGIN_ID_FIELD_NAME);
			}

			return string.Empty;
		}

		/// <summary>
		/// Check login
		/// </summary>
		/// <param name="password">Login id</param>
		/// <returns>Error message</returns>
		public static string CheckLogin(AccountDto? account,string password)
		{
			if (account?.Password != password)
			{
				return "Error Login";
			}

			return string.Empty;
		}
	}
}
