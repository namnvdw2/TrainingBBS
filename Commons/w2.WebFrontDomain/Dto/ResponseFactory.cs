// (c) 2026 W2 Co.,Ltd.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2.WebFrontDomain.Dto
{
	public static class ResponseFactory
	{
		public static BaseResponse Success(string? nextUrl = "")
		{
			return new BaseResponse
			{
				Success = true,
				RedirectUrl = nextUrl ?? string.Empty
			};
		}

		public static BaseResponse Error(string? nextUrl = "")
		{
			return new BaseResponse
			{
				Success = false,
				RedirectUrl = nextUrl ?? string.Empty
			};
		}

		public static T Success<T>(string? nextUrl = "")
			where T : BaseResponse, new()
		{
			return new T
			{
				Success = true,
				RedirectUrl = nextUrl ?? string.Empty
			};
		}

		public static T Error<T>(string? nextUrl = "")
			where T : BaseResponse, new()
		{
			return new T
			{
				Success = false,
				RedirectUrl = nextUrl ?? string.Empty
			};
		}
	}
}
