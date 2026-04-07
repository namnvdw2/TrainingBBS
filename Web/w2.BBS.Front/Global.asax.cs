using System;
using System.Web;
using System.Web.Routing;
using w2.Common;
using w2.Common.Logger;

namespace w2.BBS.Front
{
	/// <summary>
	/// グローバルアプリケーションクラス
	/// </summary>
	public class Global : HttpApplication
	{
		/// <summary>
		/// アプリケーション開始
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Application_Start(object sender, EventArgs e)
		{
			Constants.APPLICATION_NAME = "w2.BBS.Front";
			Constants.PHYSICALDIRPATH_LOGFILE = $"C:\\Logs\\Traning.BBS\\{Constants.APPLICATION_NAME}\\";
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}
		
		/// <summary>
		/// 新セッション開始
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Session_Start(object sender, EventArgs e)
		{
			this.Session["__DummyValueToFixSessionID__"] = string.Empty;
		}
		
		/// <summary>
		/// 例外発生
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Application_Error(object sender, EventArgs e)
		{
			var exception = this.Server.GetLastError();
			if (exception is HttpException httpException)
			{
				var statusCode = httpException.GetHttpCode();
				if (statusCode is 404 or 403) return; // ログ不要
			}

			FileLogger.WriteError("HTTP要求でハンドルされない例外が発生", exception);
		}
	}
}
