using System;
using System.Collections.Generic;
using System.IO;
using JA.Logging;

namespace JA.DefaultLogTargets
{
	/// <summary>
	/// Handles writing log to specified text file.
	/// </summary>
	public class TextFile : LogTarget
	{
		private StreamWriter file;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="streamwriter">Streamwriter that is logged to.</param>
		/// <param name="logLevel">Log level and log levels above are logged.</param>		
		/// <param name="logLevelBlacklist">List of log levels allways to be logged.</param>
		/// <param name="logLevelWhitelist">List of log levels never to be logged.</param>
		/// <param name="expirationTime">Time at whitch  the log target expires.</param>	
		public TextFile(StreamWriter streamwriter, LogLevel logLevel, List<LogLevel> logLevelWhitelist, List<LogLevel> logLevelBlacklist, DateTime? expirationTime)
			: base(logLevel, logLevelWhitelist, logLevelBlacklist, expirationTime)
		{
			this.file = streamwriter;
		}

		/// <summary>
		/// Writes log to specified text file
		/// </summary>
		/// <param name="logEntry">Container for log information.</param>
		public override void WriteLog(LogEntry logEntry)
		{
			this.file.WriteLine(this.CreateFormattedLogString(logEntry));
			this.file.Flush();
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
