using System;
using System.Collections.Generic;

namespace JA.Logging
{
	/// <summary>
	/// The actual implementation that handles writing the log.
	/// </summary>
	public abstract class LogTarget
	{
		/// <summary>
		/// Log level and log levels above are logged.
		/// </summary>
		public LogLevel LogLevel;

		/// <summary>
		/// List of log levels never to be logged.
		/// </summary>
		public List<LogLevel> LogLevelBlacklist
		{
			get
			{
				return this.logLevelBlacklist;
			}
			set
			{
				if(value != null)
				{
					this.logLevelBlacklist = value;
				}
				else
				{
					this.logLevelBlacklist = new List<LogLevel>();
				}
			}
		}

		/// <summary>
		/// List of log levels allways to be logged.
		/// </summary>
		public List<LogLevel> LogLevelWhitelist
		{
			get
			{
				return this.logLevelWhitelist;
			}
			set
			{
				if(value != null)
				{
					this.logLevelWhitelist = value;
				}
				else
				{
					this.logLevelWhitelist = new List<LogLevel>();
				}
			}
		}

		/// <summary>
		/// Time at whitch the log target expires.
		/// </summary>
		public DateTime? ExpirationTime
		{
			get
			{
				return this.expirationTime;
			}
			set
			{
				if(value != null)
				{
					this.expirationTime = (DateTime)value;
				}
				else
				{
					this.expirationTime = DateTime.MaxValue;
				}
			}
		}

		private List<LogLevel> logLevelBlacklist;
		private List<LogLevel> logLevelWhitelist;
		private DateTime expirationTime;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="logLevel">Log level and log levels above are logged.</param>		
		/// <param name="logLevelBlacklist">List of log levels allways to be logged.</param>
		/// <param name="logLevelWhitelist">List of log levels never to be logged.</param>
		/// <param name="expirationTime">Time at whitch  the log target expires.</param>		
		public LogTarget(LogLevel logLevel, List<LogLevel> logLevelBlacklist, List<LogLevel> logLevelWhitelist, DateTime? expirationTime)
		{
			this.LogLevel = logLevel;
			this.LogLevelBlacklist = logLevelBlacklist;
			this.LogLevelWhitelist = logLevelWhitelist;
			this.ExpirationTime = expirationTime;
		}

		/// <summary>
		/// Writes log to target.
		/// </summary>		
		public abstract void WriteLog(LogEntry logEntry);
	}
}
