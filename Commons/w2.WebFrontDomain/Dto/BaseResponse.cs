// (c) 2026 W2 Co.,Ltd.

using Newtonsoft.Json;
using SqlKata;
using System;
using System.Collections.Generic;

namespace w2.WebFrontDomain.Dto
{
	/// <summary>
	/// Base response
	/// </summary>
	[Serializable]
	public abstract class BaseResponse<T> : BaseResponse
	{
		/// <summary>Response object</summary>
		public T? ResponseObject { get; set; }
	}

	/// <summary>
	/// Base response
	/// </summary>
	[Serializable]
	public abstract class BaseResponse
	{
		/// <summary>
		/// Adds an error message for the specified key
		/// </summary>
		/// <param name="key">The key</param>
		/// <param name="message">The error message</param>
		public void AddError(string key, string message)
		{
			if (!this.Errors.ContainsKey(key))
			{
				this.Errors.Add(key, message);
			}

			this.Success = false;
		}

		/// <summary>Success flag</summary>
		public bool Success { get; set; } = true;
		/// <summary>Errors</summary>
		public Dictionary<string, string> Errors { get; set; } = new();
		/// <summary>Message</summary>
		public string Message { get; set; } = string.Empty;
		/// <summary>Redirect URL</summary>
		public string RedirectUrl { get; set; } = string.Empty;
		/// <summary>Indicates whether there are any errors</summary>
		[JsonIgnore]
		public bool HasError => this.Errors.Count > 0;
	}
}
