// (c) 2026 W2 Co.,Ltd.

namespace w2.WebFrontDomain.Dto.Users
{
	/// <summary>
	/// Login request
	/// </summary>
	public sealed class LoginRequest : BaseRequest
	{
		/// <summary>Login ID</summary>
		public string LoginId { get; set; } = string.Empty;
		/// <summary>Password</summary>
		public string Password { get; set; } = string.Empty;
	}
}
