using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using w2.Common.Logger;

namespace w2.WebFrontDomain.Validator
{
	/// <summary>
	/// CommonMessages
	/// </summary>
	public class CommonMessages
	{
		/// <summary>Message key</summary>
		public enum CommonMessageKey
		{
			/// <summary>Required field error message format</summary>
			FormatErrorRequired,
			/// <summary>Maximum length error message format</summary>
			FormatErrorMaxLength,
			/// <summary>Minimum length error message format</summary>
			FormatErrorMinLength,
			/// <summary>Alphanumeric error message format</summary>
			FormatErrorAlphanumeric,
			/// <summary>System error message</summary>
			SystemError,
			/// <summary>Error logged-in required message</summary>
			ErrorLoggedInRequired,
		}

		/// <summary>Path to the message XML file</summary>
		private static readonly string s_messageXmlPath =
			Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Xml", "Message", "CommonMessages.xml");
		/// <summary>Message dictionary</summary>
		private static readonly Dictionary<string, string> s_messages = new();
		/// <summary>Lock object for thread safety</summary>
		private static readonly object s_lockObject = new();
		/// <summary>Last load time of the message XML file</summary>
		private static DateTime s_lastLoadTime = DateTime.MinValue;
		/// <summary>Singleton instance</summary>
		private readonly static Lazy<CommonMessages> s_instance = new(() => new CommonMessages());

		/// <summary>
		/// Gets the singleton instance
		/// </summary>
		/// <returns>Instance</returns>
		public static CommonMessages GetInstance() => s_instance.Value;

		/// <summary>
		/// Constructor
		/// </summary>
		public CommonMessages()
		{
			LoadMessageXml();
		}

		/// <summary>
		/// Loads messages from the XML file
		/// </summary>
		private void LoadMessageXml()
		{
			if (File.Exists(s_messageXmlPath) == false)
			{
				FileLogger.WriteError($"Message XML file not found. PATH: {s_messageXmlPath}");
				return;
			}

			lock (s_lockObject)
			{
				if (s_lastLoadTime >= File.GetLastWriteTime(s_messageXmlPath))
				{
					return;
				}
				try
				{
					var xmlDoc = new XmlDocument();
					xmlDoc.Load(s_messageXmlPath);
					s_messages.Clear();

					foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
					{
						if (node.NodeType != XmlNodeType.Element) continue;

						var key = node.Name;
						var value = node.InnerText?.Trim();
						if ((string.IsNullOrEmpty(key) == false)
							&& (s_messages.ContainsKey(key) == false))
						{
							s_messages.Add(key, value ?? string.Empty);
						}
					}

					s_lastLoadTime = File.GetLastWriteTime(s_messageXmlPath);
				}
				catch (Exception ex)
				{
					FileLogger.WriteError($"Failed to load message XML file. PATH: {s_messageXmlPath}, ERROR: {ex.Message}");
				}
			}
		}

		/// <summary>
		/// Gets a message by key
		/// </summary>
		/// <param name="key">The message key</param>
		/// <returns>Message</returns>
		private string GetMessage(string key)
		{
			LoadMessageXml();
			lock (s_lockObject)
			{
				var message = s_messages.TryGetValue(key, out var msg) ? msg : string.Empty;
				return message;
			}
		}

		/// <summary>
		/// Gets a message by key and replacers
		/// </summary>
		/// <param name="errorKey">ErrorKey</param>
		/// <param name="replacers">Replacers</param>
		/// <returns>Message</returns>
		public static string GetMessage(CommonMessageKey errorKey, params string[] replacers)
		{
			var instance = GetInstance();
			var originMessage = instance.GetMessage(errorKey.ToString());
			for (int i = 0; i < replacers.Length; i++)
			{
				originMessage.Replace($"@@ {i} @@", replacers[i]);
			}

			return originMessage;
		}
	}
}
