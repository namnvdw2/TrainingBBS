// (c) 2025 W2 Co.,Ltd.

namespace w2.WebFrontDomain.Dto.Account
{
	/// <summary>
	/// Login request
	/// </summary>
	public sealed class LoginRequest
	{
		/// <summary>Login ID</summary>
		public string LoginId { get; set; } = string.Empty;
		/// <summary>Password</summary>
		public string Password { get; set; } = string.Empty;
		/// <summary>NextUrl</summary>
		public string NextUrl { get; set; } = string.Empty;
	}
}
