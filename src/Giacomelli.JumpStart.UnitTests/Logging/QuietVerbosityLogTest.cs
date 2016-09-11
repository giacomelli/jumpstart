using System;
using System.IO;
using NUnit.Framework;

namespace Giacomelli.JumpStart.UnitTests
{
	[TestFixture]
	public class QuietVerbosityLogTest
	{
		[Test]
		public void Debug_Args_Nothing()
		{
			TestHelper.AssertConsoleOutput(() =>
			{
				var target = new QuietVerbosityLog();
				target.Debug("Test {0}", 1);
			},
			String.Empty);
		}

		[Test]
		public void Info_Args_Nothing()
		{
			TestHelper.AssertConsoleOutput(() =>
			{
				var target = new QuietVerbosityLog();
				target.Info("Test {0}", 1);
			},
			String.Empty);
		}

		[Test]
		public void Warn_Args_Nothing()
		{
			TestHelper.AssertConsoleOutput(() =>
			{
				var target = new QuietVerbosityLog();
				target.Warn("Test {0}", 1);
			},
			String.Empty);
		}
	}
}