using System;

namespace JA.Logging
{
	/// <summary>
	/// Container for logging information.
	/// </summary>
	public class LogEntry
	{
		/// <summary>
		/// Log level at which the message is logged.
		/// </summary>
		public LogLevel LogLevel
		{
			get; private set;
		}

		/// <summary>
		/// Object containing date and time information.
		/// </summary>
		public DateTime DateTime
		{
			get; private set;
		}

		/// <summary>
		/// Name of the method from which the logger was called.
		/// </summary>
		public string SourceMemberName
		{
			get; private set;
		}

		/// <summary>
		/// Line number from which the logger was called.
		/// </summary>
		public int SourceLineNumber
		{
			get; private set;
		}

		/// <summary>
		/// Name of the class from which the logger was called.
		/// </summary>
		public string SourceClassName
		{
			get; private set;
		}

		/// <summary>
		/// Message to log
		/// </summary>
		public string Message
		{
			get; private set;
		}

		/// <summary>
		/// Writes log to target.
		/// </summary>
		/// <param name="logLevel">Log level at which the message is logged.</param>
		/// <param name="dateTime">Object containing date and time information.</param>
		/// <param name="sourceMemberName">Name of the method from which the logger was called.</param>
		/// <param name="sourceLineNumber">Line number from which the logger was called.</param>
		/// <param name="sourceClassName">Name of the class from which the logger was called.</param>
		/// <param name="message">Message to log.</param>		
		public LogEntry(LogLevel logLevel, DateTime dateTime, string sourceClassName, string sourceMemberName, int sourceLineNumber, string message)
		{
			this.LogLevel = logLevel;
			this.DateTime = dateTime;
			this.SourceClassName = sourceClassName;
			this.SourceMemberName = sourceMemberName;
			this.SourceLineNumber = sourceLineNumber;
			this.Message = message;
		}
	}
}
