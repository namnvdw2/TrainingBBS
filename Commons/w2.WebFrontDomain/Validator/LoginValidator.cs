// (c) 2025 W2 Co.,Ltd.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w2.WebFrontDomain.Dto;
using w2.WebFrontDomain.Dto.Account;

namespace w2.WebFrontDomain.Validator
{
	internal class LoginValidator
	{

		/// <summary>Title field name</summary>
		private const string TITLE_FIELD_NAME = "編集タイトル";
		/// <summary>Body field name</summary>
		private const string BODY_FIELD_NAME = "編集本文";

		/// <summary>
		/// Validate forum modify request
		/// </summary>
		/// <param name="request">The request</param>
		/// <returns>Response</returns>
		public BaseResponse Validate(LoginRequest request)
		{
			var response = new BaseResponse();
			//var titleError = CheckTitle(request.Title, TITLE_FIELD_NAME);
			//if (string.IsNullOrEmpty(titleError) == false)
			//{
			//	response.AddError(TITLE_ERROR_KEY, titleError);
			//}

			//var bodyError = CheckBody(request.Body, BODY_FIELD_NAME);
			//if (string.IsNullOrEmpty(bodyError) == false)
			//{
			//	response.AddError(BODY_ERROR_KEY, bodyError);
			//}

			//if (response.HasError) return response;

			return new BaseResponse
			{
				Success = true
			};
		}
	}
}
