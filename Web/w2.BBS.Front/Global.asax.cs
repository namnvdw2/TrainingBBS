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
		internal void Application_Start(object sender, EventArgs e)
		{
			Constants.APPLICATION_NAME = "w2.BBS.Front";
			Constants.PHYSICALDIRPATH_LOGFILE = $"C:\\Logs\\Training.BBS\\{Constants.APPLICATION_NAME}\\";
			Constants.STRING_SQL_CONNECTION = "Data Source=.\\SQLEXPRESS;database=BBS.Training;User ID=sa;Password=w2Sa;TrustServerCertificate=True;";
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}

		/// <summary>
		/// 新セッション開始
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		internal void Session_Start(object sender, EventArgs e)
		{
			this.Session["__DummyValueToFixSessionID__"] = string.Empty;
		}

		/// <summary>
		/// 例外発生
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		internal void Application_Error(object sender, EventArgs e)
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
