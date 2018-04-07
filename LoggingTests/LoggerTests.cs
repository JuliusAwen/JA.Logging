using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using JA.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public class LoggerTests
	{
		private const string TestMessageTrace = "TestMessageTrace";
		private const string TestMessageDebug = "TestMessageDebug";
		private const string TestMessageInformation = "TestMessageInformation";
		private const string TestMessageWarning = "TestMessageWarning";
		private const string TestMessageError = "TestMessageError";
		private const string TestMessageCritical = "TestMessageCritical";

		private const string SourceMemberName = "LogTestMessages";
		private const string SourceClassName = "LoggerTests";

		private const int LogFrequency = 50;
		private const int SleepTime = LogFrequency * 10;

		[TestMethod]
		public void LoggerLogLevelTraceTest()
		{
			var logTarget = new TestLogTarget(LogLevel.Trace, null, null, null);

			var logTargets = new List<LogTarget>
			{
				logTarget
			};

			var logger = new Logger(logTargets, LogFrequency);


			this.LogTestMessages(logger);
			Thread.Sleep(SleepTime);


			Assert.IsTrue(logTarget.LogEntries.Count > 0);
			Assert.AreEqual(6, logTarget.LogEntries.Count);

			var logEntriesByLogLevel = this.GetLogEntriesByLogLevel(logTarget);

			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Trace));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Debug));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Information));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Warning));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Error));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Critical));
		}

		[TestMethod]
		public void LoggerLogLevelDebugTest()
		{
			var logTarget = new TestLogTarget(LogLevel.Debug, null, null, null);

			var logTargets = new List<LogTarget>
			{
				logTarget
			};

			var logger = new Logger(logTargets, LogFrequency);


			this.LogTestMessages(logger);
			Thread.Sleep(SleepTime);


			Assert.IsTrue(logTarget.LogEntries.Count > 0);
			Assert.AreEqual(5, logTarget.LogEntries.Count);

			var logEntriesByLogLevel = this.GetLogEntriesByLogLevel(logTarget);

			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Trace));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Debug));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Information));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Warning));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Error));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Critical));
		}

		[TestMethod]
		public void LoggerLogLevelInformationTest()
		{
			var logTarget = new TestLogTarget(LogLevel.Information, null, null, null);

			var logTargets = new List<LogTarget>
			{
				logTarget
			};

			var logger = new Logger(logTargets, LogFrequency);

			this.LogTestMessages(logger);

			Thread.Sleep(SleepTime);


			Assert.IsTrue(logTarget.LogEntries.Count > 0);
			Assert.AreEqual(4, logTarget.LogEntries.Count);

			var logEntriesByLogLevel = this.GetLogEntriesByLogLevel(logTarget);

			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Trace));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Debug));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Information));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Warning));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Error));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Critical));
		}

		[TestMethod]
		public void LoggerLogLevelWarningTest()
		{
			var logTarget = new TestLogTarget(LogLevel.Warning, null, null, null);

			var logTargets = new List<LogTarget>
			{
				logTarget
			};

			var logger = new Logger(logTargets, LogFrequency);


			this.LogTestMessages(logger);
			Thread.Sleep(SleepTime);


			Assert.IsTrue(logTarget.LogEntries.Count > 0);
			Assert.AreEqual(3, logTarget.LogEntries.Count);

			var logEntriesByLogLevel = this.GetLogEntriesByLogLevel(logTarget);

			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Trace));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Debug));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Information));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Warning));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Error));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Critical));
		}

		[TestMethod]
		public void LoggerLogLevelErrorTest()
		{
			var logTarget = new TestLogTarget(LogLevel.Error, null, null, null);

			var logTargets = new List<LogTarget>
			{
				logTarget
			};

			var logger = new Logger(logTargets, LogFrequency);


			this.LogTestMessages(logger);
			Thread.Sleep(SleepTime);


			Assert.IsTrue(logTarget.LogEntries.Count > 0);
			Assert.AreEqual(2, logTarget.LogEntries.Count);

			var logEntriesByLogLevel = this.GetLogEntriesByLogLevel(logTarget);

			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Trace));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Debug));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Information));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Warning));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Error));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Critical));
		}

		[TestMethod]
		public void LoggerLogLevelCriticalTest()
		{
			var logTarget = new TestLogTarget(LogLevel.Critical, null, null, null);

			var logTargets = new List<LogTarget>
			{
				logTarget
			};

			var logger = new Logger(logTargets, LogFrequency);


			this.LogTestMessages(logger);
			Thread.Sleep(SleepTime);


			Assert.IsTrue(logTarget.LogEntries.Count > 0);
			Assert.AreEqual(1, logTarget.LogEntries.Count);

			var logEntriesByLogLevel = this.GetLogEntriesByLogLevel(logTarget);

			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Trace));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Debug));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Information));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Warning));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Error));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Critical));
		}

		public void LoggerLogLevelNoneTest()
		{
			var logTarget = new TestLogTarget(LogLevel.None, null, null, null);

			var logTargets = new List<LogTarget>
			{
				logTarget
			};

			var logger = new Logger(logTargets, LogFrequency);


			this.LogTestMessages(logger);
			Thread.Sleep(SleepTime);


			Assert.IsTrue(logTarget.LogEntries.Count == 0);

			var logEntriesByLogLevel = this.GetLogEntriesByLogLevel(logTarget);

			Assert.IsTrue(logTarget.LogEntries.Count == 0);
		}

		[TestMethod]
		public void LoggerLogEntriesContainAllInformationTest()
		{
			var logTarget = new TestLogTarget(LogLevel.Trace, null, null, null);

			var logTargets = new List<LogTarget>
			{
				logTarget
			};

			var logger = new Logger(logTargets, LogFrequency);


			this.LogTestMessages(logger);
			Thread.Sleep(SleepTime);


			Assert.IsTrue(logTarget.LogEntries.Count > 0);
			Assert.AreEqual(6, logTarget.LogEntries.Count);

			var logEntriesByLogLevel = this.GetLogEntriesByLogLevel(logTarget);

			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Trace));
			Assert.AreEqual(LogLevel.Trace, logEntriesByLogLevel[LogLevel.Trace].LogLevel);
			Assert.AreEqual(SourceMemberName, logEntriesByLogLevel[LogLevel.Trace].SourceMemberName);
			Assert.AreEqual(SourceClassName, logEntriesByLogLevel[LogLevel.Trace].SourceClassName);
			Assert.AreEqual(TestMessageTrace, logEntriesByLogLevel[LogLevel.Trace].Message);

			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Debug));
			Assert.AreEqual(LogLevel.Debug, logEntriesByLogLevel[LogLevel.Debug].LogLevel);
			Assert.AreEqual(SourceMemberName, logEntriesByLogLevel[LogLevel.Debug].SourceMemberName);
			Assert.AreEqual(SourceClassName, logEntriesByLogLevel[LogLevel.Debug].SourceClassName);
			Assert.AreEqual(TestMessageDebug, logEntriesByLogLevel[LogLevel.Debug].Message);

			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Information));
			Assert.AreEqual(LogLevel.Information, logEntriesByLogLevel[LogLevel.Information].LogLevel);
			Assert.AreEqual(SourceMemberName, logEntriesByLogLevel[LogLevel.Information].SourceMemberName);
			Assert.AreEqual(SourceClassName, logEntriesByLogLevel[LogLevel.Information].SourceClassName);
			Assert.AreEqual(TestMessageInformation, logEntriesByLogLevel[LogLevel.Information].Message);

			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Warning));
			Assert.AreEqual(LogLevel.Warning, logEntriesByLogLevel[LogLevel.Warning].LogLevel);
			Assert.AreEqual(SourceMemberName, logEntriesByLogLevel[LogLevel.Warning].SourceMemberName);
			Assert.AreEqual(SourceClassName, logEntriesByLogLevel[LogLevel.Warning].SourceClassName);
			Assert.AreEqual(TestMessageWarning, logEntriesByLogLevel[LogLevel.Warning].Message);

			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Error));
			Assert.AreEqual(LogLevel.Error, logEntriesByLogLevel[LogLevel.Error].LogLevel);
			Assert.AreEqual(SourceMemberName, logEntriesByLogLevel[LogLevel.Error].SourceMemberName);
			Assert.AreEqual(SourceClassName, logEntriesByLogLevel[LogLevel.Error].SourceClassName);
			Assert.AreEqual(TestMessageError, logEntriesByLogLevel[LogLevel.Error].Message);

			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Critical));
			Assert.AreEqual(LogLevel.Critical, logEntriesByLogLevel[LogLevel.Critical].LogLevel);
			Assert.AreEqual(SourceMemberName, logEntriesByLogLevel[LogLevel.Critical].SourceMemberName);
			Assert.AreEqual(SourceClassName, logEntriesByLogLevel[LogLevel.Critical].SourceClassName);
			Assert.AreEqual(TestMessageCritical, logEntriesByLogLevel[LogLevel.Critical].Message);
		}

		[TestMethod]
		public void LoggerMultipleLogTargetsSameLogLevelTest()
		{
			var logTarget1 = new TestLogTarget(LogLevel.Trace, null, null, null);
			var logTarget2 = new TestLogTarget(LogLevel.Trace, null, null, null);

			var logTargets = new List<LogTarget>
			{
				logTarget1,
				logTarget2
			};

			var logger = new Logger(logTargets, LogFrequency);


			this.LogTestMessages(logger);
			Thread.Sleep(SleepTime);


			foreach(TestLogTarget logTarget in logTargets)
			{
				Assert.IsTrue(logTarget.LogEntries.Count > 0);
				Assert.AreEqual(6, logTarget.LogEntries.Count);

				var logEntriesByLogLevel = this.GetLogEntriesByLogLevel(logTarget);

				Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Trace));
				Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Debug));
				Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Information));
				Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Warning));
				Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Error));
				Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Critical));
			}
		}

		[TestMethod]
		public void LoggerMultipleLogTargetsDifferentLogLevelTest()
		{
			var logTarget1 = new TestLogTarget(LogLevel.Trace, null, null, null);
			var logTarget2 = new TestLogTarget(LogLevel.Debug, null, null, null);

			var logTargets = new List<LogTarget>
			{
				logTarget1,
				logTarget2
			};

			var logger = new Logger(logTargets, LogFrequency);


			this.LogTestMessages(logger);
			Thread.Sleep(SleepTime);


			Assert.IsTrue(logTarget1.LogEntries.Count > 0);
			Assert.AreEqual(6, logTarget1.LogEntries.Count);

			var logEntriesByLogLevel = this.GetLogEntriesByLogLevel(logTarget1);

			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Trace));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Debug));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Information));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Warning));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Error));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Critical));


			Assert.IsTrue(logTarget2.LogEntries.Count > 0);
			Assert.AreEqual(5, logTarget2.LogEntries.Count);

			logEntriesByLogLevel = this.GetLogEntriesByLogLevel(logTarget2);

			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Trace));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Debug));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Information));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Warning));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Error));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Critical));
		}

		[TestMethod]
		public void LoggerLogLevelBlacklistSingleEntryTest()
		{
			var logLevelBlacklist = new List<LogLevel>
			{
				LogLevel.Critical
			};

			var logTarget = new TestLogTarget(LogLevel.Trace, logLevelBlacklist, null, null);

			var logTargets = new List<LogTarget>
			{
				logTarget
			};

			var logger = new Logger(logTargets, LogFrequency);


			this.LogTestMessages(logger);
			Thread.Sleep(SleepTime);


			Assert.IsTrue(logTarget.LogEntries.Count > 0);
			Assert.AreEqual(5, logTarget.LogEntries.Count);

			var logEntriesByLogLevel = this.GetLogEntriesByLogLevel(logTarget);

			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Trace));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Debug));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Information));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Warning));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Error));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Critical));
		}

		[TestMethod]
		public void LoggerLogLevelBlacklistMultipleEntriesTest()
		{
			var logLevelBlacklist = new List<LogLevel>
			{
				LogLevel.Error,
				LogLevel.Critical
			};

			var logTarget = new TestLogTarget(LogLevel.Trace, logLevelBlacklist, null, null);

			var logTargets = new List<LogTarget>
			{
				logTarget
			};

			var logger = new Logger(logTargets, LogFrequency);


			this.LogTestMessages(logger);
			Thread.Sleep(SleepTime);


			Assert.IsTrue(logTarget.LogEntries.Count > 0);
			Assert.AreEqual(4, logTarget.LogEntries.Count);

			var logEntriesByLogLevel = this.GetLogEntriesByLogLevel(logTarget);

			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Trace));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Debug));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Information));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Warning));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Error));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Critical));
		}

		[TestMethod]
		public void LoggerLogLevelWhitelistSingleEntryTest()
		{
			var logLevelWhitelist = new List<LogLevel>
			{
				LogLevel.Trace
			};

			var logTarget = new TestLogTarget(LogLevel.Critical, null, logLevelWhitelist, null);

			var logTargets = new List<LogTarget>
			{
				logTarget
			};

			var logger = new Logger(logTargets, LogFrequency);


			this.LogTestMessages(logger);
			Thread.Sleep(SleepTime);


			Assert.IsTrue(logTarget.LogEntries.Count > 0);
			Assert.AreEqual(2, logTarget.LogEntries.Count);

			var logEntriesByLogLevel = this.GetLogEntriesByLogLevel(logTarget);

			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Trace));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Debug));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Information));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Warning));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Error));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Critical));
		}

		[TestMethod]
		public void LoggerLogLevelWhitelistMultipleEntriesTest()
		{
			var logLevelWhitelist = new List<LogLevel>
			{
				LogLevel.Trace,
				LogLevel.Debug
			};

			var logTarget = new TestLogTarget(LogLevel.Critical, null, logLevelWhitelist, null);

			var logTargets = new List<LogTarget>
			{
				logTarget
			};

			var logger = new Logger(logTargets, LogFrequency);


			this.LogTestMessages(logger);
			Thread.Sleep(SleepTime);


			Assert.IsTrue(logTarget.LogEntries.Count > 0);
			Assert.AreEqual(3, logTarget.LogEntries.Count);

			var logEntriesByLogLevel = this.GetLogEntriesByLogLevel(logTarget);

			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Trace));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Debug));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Information));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Warning));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Error));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Critical));
		}

		[TestMethod]
		public void LoggerLogLevelWhitelistAndBlacklistTest()
		{
			var logLevelBlacklist = new List<LogLevel>
			{
				LogLevel.Critical
			};

			var logLevelWhitelist = new List<LogLevel>
			{
				LogLevel.Trace
			};

			var logTarget = new TestLogTarget(LogLevel.Information, logLevelBlacklist, logLevelWhitelist, null);

			var logTargets = new List<LogTarget>
			{
				logTarget
			};

			var logger = new Logger(logTargets, LogFrequency);


			this.LogTestMessages(logger);
			Thread.Sleep(SleepTime);


			Assert.IsTrue(logTarget.LogEntries.Count > 0);
			Assert.AreEqual(4, logTarget.LogEntries.Count);

			var logEntriesByLogLevel = this.GetLogEntriesByLogLevel(logTarget);

			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Trace));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Debug));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Information));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Warning));
			Assert.IsTrue(logEntriesByLogLevel.ContainsKey(LogLevel.Error));
			Assert.IsFalse(logEntriesByLogLevel.ContainsKey(LogLevel.Critical));
		}

		[TestMethod]
		public void LoggerLogTargetTerminationTest()
		{
			var logTarget = new TestLogTarget(LogLevel.Trace, null, null, DateTime.Now.AddMilliseconds(SleepTime * 2));

			var logTargets = new List<LogTarget>
			{
				logTarget
			};

			var logger = new Logger(logTargets, LogFrequency);


			this.LogTestMessages(logger);
			Thread.Sleep(SleepTime);
			this.LogTestMessages(logger);

			Assert.IsTrue(logTarget.LogEntries.Count > 0);
			Assert.AreEqual(6, logTarget.LogEntries.Count);
		}

		private void LogTestMessages(Logger logger)
		{
			logger.Trace(TestMessageTrace);
			logger.Debug(TestMessageDebug);
			logger.Information(TestMessageInformation);
			logger.Warning(TestMessageWarning);
			logger.Error(TestMessageError);
			logger.Critical(TestMessageCritical);
		}

		private Dictionary<LogLevel, LogEntry> GetLogEntriesByLogLevel(TestLogTarget logTarget)
		{
			var logEntriesByLogLevel = new Dictionary<LogLevel, LogEntry>();

			foreach(var logEntry in logTarget.LogEntries)
			{
				logEntriesByLogLevel[logEntry.LogLevel] = logEntry;
			}

			return logEntriesByLogLevel;
		}
	}

	public class TestLogTarget : LogTarget
	{
		public List<LogEntry> LogEntries = new List<LogEntry>();

		public TestLogTarget(LogLevel logLevel, List<LogLevel> logLevelBlacklist, List<LogLevel> logLevelWhitelist, DateTime? expirationTime)
			: base(logLevel, logLevelBlacklist, logLevelWhitelist, expirationTime) { }

		public override void WriteLog(LogEntry logEntry)
		{
			this.LogEntries.Add(logEntry);
			Trace.WriteLine($"[{logEntry.LogLevel}][{logEntry.DateTime.ToString()}][{logEntry.SourceClassName}.{logEntry.SourceMemberName} Line {logEntry.SourceLineNumber}]: {logEntry.Message}");
		}
	}
}
