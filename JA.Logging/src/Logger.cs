using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace JA.Logging
{
	/// <summary>
	/// Simple asynchronous logger.
	/// </summary>
	public class Logger
	{
		/// <summary>
		/// List of targets to which log entries are sent.
		/// </summary>
		public List<LogTarget> LogTargets
		{
			get
			{
				return this.logTargets;
			}
			set
			{
				value?.RemoveAll(entry => entry == null);
				if(value != null)
				{
					this.logTargets = value;
				}
				else
				{
					this.logTargets = new List<LogTarget>();
				}
			}
		}

		/// <summary>
		/// Frequency with which individual log entries are issued - the higher this value the less performance is needed.
		/// </summary>
		public int LogFrequencyInMS
		{
			set
			{
				if(value > 1)
				{
					this.logFrequencyInMS = value;
				}
				else
				{
					this.logFrequencyInMS = 1;
				}
			}
		}

		private List<LogTarget> logTargets;
		private int logFrequencyInMS;
		private Timer timer;
		private ConcurrentQueue<LogEntry> logQueue = new ConcurrentQueue<LogEntry>();

		/// <summary>
		/// Constructor
		/// </summary>		
		/// <param name="logTargets">List of targets to which log entries are sent.</param>		
		/// <param name="logFrequencyInMS">Frequency with which individual log entries are issued - the higher this value the less performance is needed.</param>		
		public Logger(List<LogTarget> logTargets, int logFrequencyInMS)
		{
			this.LogTargets = logTargets;
			this.LogFrequencyInMS = logFrequencyInMS;

			this.timer = new Timer(new TimerCallback(this.Log), null, 0, logFrequencyInMS);
		}

		/// <summary>
		/// Logs text to given log target at log level TRACE.
		/// </summary>
		/// <param name="message">message to log</param>		
		/// <param name="sourceMemberName">Name of the method from which the logger was called (automatically generated).</param>
		/// <param name="sourceFilePath">Path of the class from which the logger was called (automatically generated).</param>
		/// <param name="sourceLineNumber">Line number from which the logger was called (automatically generated).</param>
		public void Trace(string message, [CallerMemberName] string sourceMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
		{
			if(message != null)
			{				
				var logEntry = new LogEntry(
					LogLevel.Trace,
					DateTime.Now,
					this.ParseSourceClassNameFromSourceFilePath(sourceFilePath),
					this.FormatSourceMemberName(sourceMemberName),
					sourceLineNumber,
					message
				);

				this.logQueue.Enqueue(logEntry);
			}
		}

		/// <summary>
		/// Logs text to given log target at log level DEBUG.
		/// </summary>
		/// <param name="message">message to log</param>		
		/// <param name="sourceMemberName">Name of the method from which the logger was called (automatically generated).</param>
		/// <param name="sourceFilePath">Path of the class from which the logger was called (automatically generated).</param>
		/// <param name="sourceLineNumber">Line number from which the logger was called (automatically generated).</param>
		public void Debug(string message, [CallerMemberName] string sourceMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
		{
			if(message != null)
			{
				var logEntry = new LogEntry(
					LogLevel.Debug,
					DateTime.Now,
					this.ParseSourceClassNameFromSourceFilePath(sourceFilePath),
					this.FormatSourceMemberName(sourceMemberName),
					sourceLineNumber,
					message
				);

				this.logQueue.Enqueue(logEntry);
			}
		}

		/// <summary>
		/// Logs text to given log target at log level INFO.
		/// </summary>
		/// <param name="message">message to log</param>		
		/// <param name="sourceMemberName">Name of the method from which the logger was called (automatically generated).</param>
		/// <param name="sourceFilePath">Path of the class from which the logger was called (automatically generated).</param>
		/// <param name="sourceLineNumber">Line number from which the logger was called (automatically generated).</param>
		public void Information(string message, [CallerMemberName] string sourceMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
		{
			if(message != null)
			{
				var logEntry = new LogEntry(
					LogLevel.Information,
					DateTime.Now,
					this.ParseSourceClassNameFromSourceFilePath(sourceFilePath),
					this.FormatSourceMemberName(sourceMemberName),
					sourceLineNumber,
					message
				);

				this.logQueue.Enqueue(logEntry);
			}
		}

		/// <summary>
		/// Logs text to given log target at log level WARNING.
		/// </summary>
		/// <param name="message">message to log</param>		
		/// <param name="sourceMemberName">Name of the method from which the logger was called (automatically generated).</param>
		/// <param name="sourceFilePath">Path of the class from which the logger was called (automatically generated).</param>
		/// <param name="sourceLineNumber">Line number from which the logger was called (automatically generated).</param>
		public void Warning(string message, [CallerMemberName] string sourceMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
		{
			if(message != null)
			{
				var logEntry = new LogEntry(
					LogLevel.Warning,
					DateTime.Now,
					this.ParseSourceClassNameFromSourceFilePath(sourceFilePath),
					this.FormatSourceMemberName(sourceMemberName),
					sourceLineNumber,
					message
				);

				this.logQueue.Enqueue(logEntry);
			}
		}

		/// <summary>
		/// Logs text to given log target at log level ERROR.
		/// </summary>
		/// <param name="message">message to log</param>		
		/// <param name="sourceMemberName">Name of the method from which the logger was called (automatically generated).</param>
		/// <param name="sourceFilePath">Path of the class from which the logger was called (automatically generated).</param>
		/// <param name="sourceLineNumber">Line number from which the logger was called (automatically generated).</param>
		public void Error(string message, [CallerMemberName] string sourceMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
		{
			if(message != null)
			{
				var logEntry = new LogEntry(
					LogLevel.Error,
					DateTime.Now,
					this.ParseSourceClassNameFromSourceFilePath(sourceFilePath),
					this.FormatSourceMemberName(sourceMemberName),
					sourceLineNumber,
					message
				);

				this.logQueue.Enqueue(logEntry);
			}
		}

		/// <summary>
		/// Logs text to given log target at log level CRITICAL.
		/// </summary>
		/// <param name="message">message to log</param>		
		/// <param name="sourceMemberName">Name of the method from which the logger was called (automatically generated).</param>
		/// <param name="sourceFilePath">Path of the class from which the logger was called (automatically generated).</param>
		/// <param name="sourceLineNumber">Line number from which the logger was called (automatically generated).</param>
		public void Critical(string message, [CallerMemberName] string sourceMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
		{
			if(message != null)
			{
				var logEntry = new LogEntry(
					LogLevel.Critical,
					DateTime.Now,
					this.ParseSourceClassNameFromSourceFilePath(sourceFilePath),
					this.FormatSourceMemberName(sourceMemberName),
					sourceLineNumber,
					message
				);

				this.logQueue.Enqueue(logEntry);
			}
		}

		private string FormatSourceMemberName(string sourceMemberName)
		{
			return sourceMemberName.Equals(".ctor") ? "Constructor" : sourceMemberName;
		}

		private string ParseSourceClassNameFromSourceFilePath(string sourceFilePath)
		{
			return sourceFilePath.Substring(sourceFilePath.LastIndexOf("\\") + 1).Split('.')[0];			
		}

		private void Log(Object obj)
		{
			if(this.logQueue.TryDequeue(out LogEntry logEntry))
			{
				var logTargetsToTerminate = new List<LogTarget>();

				foreach(var logTarget in this.LogTargets)
				{
					if(logTarget.ExpirationTime <= DateTime.Now)
					{
						logTargetsToTerminate.Add(logTarget);
					}
					else
					{
						if(this.IsMessageToBeLogged(logTarget, logEntry.LogLevel))
						{
							logTarget.WriteLog(logEntry);
						}
					}
				}

				foreach(var logTargetToTerminate in logTargetsToTerminate)
				{
					this.LogTargets.Remove(logTargetToTerminate);
				}
			}
		}

		private bool IsMessageToBeLogged(LogTarget logTarget, LogLevel logLevel)
		{
			return (logLevel != LogLevel.None && !logTarget.LogLevelBlacklist.Contains(logLevel) && (logLevel >= logTarget.LogLevel || logTarget.LogLevelWhitelist.Contains(logLevel)));
		}
	}
}
