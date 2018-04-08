using System;
using System.Collections.Generic;
using JA.Logging;

namespace JA.DefaultLogTargets.src
{
	/// <summary>
	/// Handles writing log to System.Console.
	/// </summary>
	public class SystemConsole : LogTarget
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="logLevel">Log level and log levels above are logged.</param>		
		/// <param name="logLevelBlacklist">List of log levels allways to be logged.</param>
		/// <param name="logLevelWhitelist">List of log levels never to be logged.</param>
		/// <param name="expirationTime">Time at whitch  the log target expires.</param>	
		public SystemConsole(LogLevel logLevel, List<LogLevel> logLevelBlacklist, List<LogLevel> logLevelWhitelist, DateTime? expirationTime)
			: base(logLevel, logLevelWhitelist, logLevelBlacklist, expirationTime)
		{
		}

		/// <summary>
		/// Writes log to System.Console
		/// </summary>
		/// <param name="logEntry">Container for log information.</param>
		public override void WriteLog(LogEntry logEntry)
		{
			Console.WriteLine(this.CreateFormattedLogString(logEntry));
		}

		/// <summary>
		/// Creates formatted log string
		/// </summary>
		/// <param name="logEntry">Container for log information.</param>
		/// <returns>Returns formatted log string</returns>
		private string CreateFormattedLogString(LogEntry logEntry)
		{
			return $"[{logEntry.LogLevel}][{logEntry.DateTime.ToLongTimeString()}][{logEntry.SourceClassName}.{logEntry.SourceMemberName} Line {logEntry.SourceLineNumber}]: {logEntry.Message}";
		}
	}
}
