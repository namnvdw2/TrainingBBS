// (c) 2026 W2 Co.,Ltd.

using System;

namespace w2.WebFrontDomain.Dto
{
	/// <summary>
	/// Base request
	/// </summary>
	[Serializable]
	public class BaseRequest
	{
		/// <summary>NextUrl</summary>
		public string? NextUrl { get; set; } = null;
	}
}
