// (c) 2026 W2 Co.,Ltd.

namespace w2.WebFrontDomain.Dto.Account
{
	/// <summary>
	/// Account register modify request
	/// </summary>
	public sealed class AccountRegisterModifyRequest : BaseRequest
	{
		/// <summary>Login id</summary>
		public string LoginId { get; set; } = string.Empty;
		/// <summary>Password</summary>
		public string Password { get; set; } = string.Empty;
		/// <summary>Name</summary>
		public string Name { get; set; } = string.Empty;
	}
}
